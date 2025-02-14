using UnityEngine;
using UnityEngine.UI;

namespace NEDDY
{
    public class InventorySlot : MonoBehaviour
    {
        public Image icon; // 道具图标 (顯示在 UI)
        public Button button; // 道具槽按钮
        public bool 佔用狀態 = false; // 子物件的狀態

        void Update()
        {
            // 檢查是否有子物件
            佔用狀態 = transform.childCount > 0;

            if (佔用狀態)
            {
                // 取得第一個子物件的 Item 組件
                Item item = transform.GetChild(0).GetComponent<Item>();

                // 如果找到 Item，將圖示更新到 UI 上
                if (item != null)
                {
                    icon.sprite = item.icon;
                    icon.enabled = true; // 確保 Image 顯示
                }
            }
            else
            {
                // 若沒有子物件，清空圖示
                icon.sprite = null;
                icon.enabled = false;
            }
        }
    }
}
