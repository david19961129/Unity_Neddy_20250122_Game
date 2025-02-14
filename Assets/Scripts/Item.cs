using UnityEngine;

namespace NEDDY
{
    public class Item : MonoBehaviour
    {
        public string itemName; // 道具名称
        public Sprite icon;     // 道具縮圖
        public string description; // 道具描述
        GameObject player; // 存储玩家对象
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player"); // 找到玩家
        }

        void Update()
        {
            CheckPickupLetter(); // 每幀執行檢查是否撿起道具
        }
        private void CheckPickupLetter()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                float distanceToLetter = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
                if (distanceToLetter < 2.0f)
                {
                    transform.SetParent(player.transform);
                    transform.localPosition = new Vector3(0, 0.5f, 1);
                    Debug.Log(gameObject.name + "道具以撿起並 已成為 " + player.name + " 的子物件");
                    gameObject.SetActive(false);
                }
            }
        }
    }
}

        

