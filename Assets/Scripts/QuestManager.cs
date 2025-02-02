using UnityEngine;

namespace NEDDY
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance; // 单例实例

        public GameObject 信封; // 信封的游戏对象
        public GameObject 郵箱; // 邮箱的游戏对象
        public bool isQuestAccepted = false; // 是否接受了任务
        public bool isLetterDelivered = false; // 信是否已送达

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this; // 设置单例实例
            }
            else
            {
                Destroy(gameObject); // 防止重复创建
            }
        }

        private void Start()
        {
            // 动态查找场景中的对象
            信封 = GameObject.Find("信封");
            郵箱 = GameObject.Find("郵箱");

            if (信封 == null || 郵箱 == null)
            {
                Debug.LogError("未找到 信封 或 郵箱 对象！");
            }
        }

        // 接受任务
        public void AcceptQuest()
        {
            isQuestAccepted = true;
            信封.SetActive(true); // 显示信封
            Debug.Log("任务已接受：请将信送到邮箱。");
        }

        // 拒绝任务
        public void DeclineQuest()
        {
            isQuestAccepted = false;
            Debug.Log("任务已拒绝。");
        }

        // 检查信是否送达
        public void CheckDelivery()
        {
            if (isQuestAccepted && !isLetterDelivered)
            {
                float distance = Vector3.Distance(信封.transform.position, 郵箱.transform.position);
                if (distance < 2.0f) // 如果信靠近邮箱
                {
                    isLetterDelivered = true;
                    信封.SetActive(false); // 隐藏信封
                    Debug.Log("任务完成：信已送达邮箱！");
                }
            }
        }

        void Update()
        {
            if (isQuestAccepted && !isLetterDelivered)
            {
                CheckDelivery(); // 每帧检查信是否送达
            }
        }
    }
}