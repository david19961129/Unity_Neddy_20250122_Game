using UnityEngine;

namespace NEDDY
{
    public class Item : MonoBehaviour
    {
        public string itemName;   // 道具名稱
        public Sprite icon;       // 道具縮圖
        public string description; // 道具描述

        private Transform 待分類道具;
        private GameObject player;
        private InventoryManager inventoryManager;

        void Start()
        {
            待分類道具 = GameObject.Find("版本二/小貓/背包UI/待分類道具").transform;
            player = GameObject.FindGameObjectWithTag("Player");
            inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
        }

        void Update()
        {
            CheckPickupLetter(); // 每幀檢查是否撿起道具
        }

        private void CheckPickupLetter()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                float distanceToLetter = Vector3.Distance(transform.position, player.transform.position);
                if (distanceToLetter < 1.0f)
                {
                    PlaceItemInPocket(); // 找到合適的口袋並存放道具
                }
            }
        }

        private void PlaceItemInPocket()
        {
            if (inventoryManager == null || inventoryManager.itemSlotsParent == null)
            {
                Debug.LogError("InventoryManager 或 itemSlotsParent 未正確設置！");
                return;
            }

            foreach (Transform pocket in inventoryManager.itemSlotsParent) // 直接遍歷所有口袋
            {
                InventorySlot slot = pocket.GetComponent<InventorySlot>(); // 獲取口袋的狀態腳本
                if (slot != null && !slot.佔用狀態) // 如果口袋是空的
                {
                    transform.SetParent(pocket); // 設置道具為該口袋的子物件
                    transform.localPosition = Vector3.zero; // 重設位置
                    slot.佔用狀態 = true; // 設置口袋為已佔用
                    gameObject.SetActive(false); // 撿起後隱藏道具
                    Debug.Log($"道具 {itemName} 已放入口袋 {pocket.name}");
                    return; // 成功放入後，結束函式
                }
            }

            Debug.Log("所有口袋已滿，無法存放道具！");
        }
    }
}
