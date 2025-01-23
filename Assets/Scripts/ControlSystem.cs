using UnityEngine;

namespace NEDDY
{
    public class ControlSystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Tooltip("用於調整速度"), Range(0, 10)] private float moveSpeed = 3.3f;

        private Rigidbody2D rig;
        private Animator ani;
        private string parMove = "移動數值";

        //屬性面板2存取方式:1.公開屬性。2.公開方式
        //是否能控制
        public bool canControl { get; set; }=false;
        public bool canMove { get; set; } = false;

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
            Test_CanControl();
            //如果不能控制就跳出
            if (!canControl) return;
            Move();
            Filp();
        }

        private void Move()
        {
            if (!canControl) return;
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            rig.velocity = new Vector2(h, v) * moveSpeed;


            ani.SetFloat(parh, (h));
            ani.SetFloat(parv, (v));

        }


        private void Filp()
        {

        }

        public void StopAllControl()
        {
            canControl = false;
            rig.velocity = Vector2.zero;
            ani.SetFloat (parMove, 0);
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
                canControl=true;
                canMove=true;
            }
        }

#endif
    }

}