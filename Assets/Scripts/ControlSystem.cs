using UnityEngine;

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

    // 引用 QuestManager
    private QuestManager questManager;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        // 查找 QuestManager
        questManager = FindObjectOfType<QuestManager>();
        if (questManager == null)
        {
            Debug.LogError("未找到 QuestManager！");
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        Test_CanControl();
#endif
        Test_CanControl();
        // 如果不能控制就跳出
        if (!canControl) return;
        Move();
        CheckPickupLetter();
    }

    private void Move()
    {
        if (!canControl) return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(h, v) * moveSpeed;

        ani.SetFloat("H", h);
        ani.SetFloat("V", v);
    }

    // 检查是否拾取信
    private void CheckPickupLetter()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distanceToLetter = Vector3.Distance(transform.position, questManager.信封.transform.position);
            if (distanceToLetter < 2.0f)
            {
                questManager.信封.transform.SetParent(transform); // 将信设为玩家的子对象
                questManager.信封.transform.localPosition = new Vector3(0, 1, 1); // 调整信的位置
                Debug.Log("你拾取了信。");
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