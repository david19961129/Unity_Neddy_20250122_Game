using UnityEngine;
using Fungus;

public class QuestManager : MonoBehaviour
{
    public GameObject 信封; // 信封的游戏对象
    public GameObject 郵箱; // 邮箱的游戏对象
    public bool isQuestAccepted = false; // 是否接受了任务
    public bool isLetterDelivered = false; // 信是否已送达

    public Flowchart flowchart; // 引用 Fungus 的 Flowchart

    private void Start()
    {
        信封.SetActive(false); // 初始隐藏
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
    public void CheckDelivery(Transform player)
    {
        if (isQuestAccepted && !isLetterDelivered)
        {
            float distance = Vector3.Distance(player.position, 郵箱.transform.position);
            if (distance < 2.0f) // 如果玩家靠近邮箱
            {
                isLetterDelivered = true;
                信封.SetActive(false); // 隐藏信封
                Debug.Log("任务完成：信已送达邮箱！");

                // 更新 Fungus 变量
                if (flowchart != null)
                {
                    flowchart.SetBooleanVariable("isLetterDelivered", true);
                }
            }
        }
    }
}