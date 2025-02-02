using UnityEngine;

namespace NEDDY
{
    public class ControlSystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Tooltip("用於調整速度"), Range(0, 10)]
        private float moveSpeed = 3.3f;

        private Rigidbody2D rig;
        private Animator ani;
        private string parMove = "移動數值";

        // 是否能控制
        public bool canControl { get; set; } = false;
        public bool canMove { get; set; } = false;

        // 任务相关变量
        public GameObject 信封; // 信的游戏对象
        public float pickupDistance = 2.0f; // 拾取距离
        private GameObject 郵箱; // 參考郵箱
        public float deliveryDistance = 2.0f; // 送信距離

        private void Start()
        {
            // 動態查找郵箱物件
            郵箱 = GameObject.Find("郵箱");
        }

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        private string parh = "H";
        private string parv = "V";

        private void Update()
        {
#if UNITY_EDITOR
            Test_CanControl();
#endif
            if (!canControl) return;

            Move();
            Filp();
            CheckPickupLetter();  // 撿信
            CheckDeliverLetter(); // 送信
        }

        private void Move()
        {
            if (!canControl) return;
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            rig.velocity = new Vector2(h, v) * moveSpeed;

            ani.SetFloat(parh, h);
            ani.SetFloat(parv, v);
        }

        private void Filp()
        {
            // 翻转逻辑（如果需要）
        }

        // 检查是否拾取信
        private void CheckPickupLetter()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                float distanceToLetter = Vector3.Distance(transform.position,信封.transform.position);
                if (distanceToLetter < pickupDistance)
                {
                    信封.transform.SetParent(transform); // 将信设为玩家的子对象
                    信封.transform.localPosition = new Vector3(0, 1, 1); // 调整信的位置
                    Debug.Log("你拾取了信。");
                }
            }
        }
        private void CheckDeliverLetter()
        {
            if (Input.GetKeyDown(KeyCode.E) && 信封.transform.parent == transform) // 玩家手上有信
            {
                float distanceToMailbox = Vector3.Distance(transform.position, 郵箱.transform.position);
                if (distanceToMailbox < deliveryDistance)
                {
                    // 設定信封位置到郵箱內
                    信封.transform.SetParent(null);
                    信封.transform.position = 郵箱.transform.position + new Vector3(0, 1, 0);
                    信封.SetActive(false); // 隱藏信封
                    QuestManager.Instance.isLetterDelivered = true;
                    Debug.Log("你成功送達了信！");
                }
            }
        }
        public void StopAllControl()
        {
            canControl = false;
            rig.velocity = Vector2.zero;
            ani.SetFloat(parMove, 0);
        }

        /// <summary>
        /// 開啟所有控制=NPC對話上使用
        /// </summary>
        public void OpenAllControl()
        {
            canControl = true;
        }

#if UNITY_EDITOR
        /// <summary>
        /// 測試用:全開
        /// 按1才能啟動
        /// </summary>
        private void Test_CanControl()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                canControl = true;
                canMove = true;
            }
        }
#endif
    }
}