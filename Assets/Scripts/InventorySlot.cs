using UnityEngine;
using UnityEngine.UI;

namespace NEDDY
{
    public class InventorySlot : MonoBehaviour
    {
        public Image icon; // 道具圖標 (顯示在 UI)
        public Button button; // 道具槽按鈕
        public bool 佔用狀態 = false; // 子物件的狀態

        void Update()
        {
            // 只有當有子物件時才更新 icon
            if (transform.childCount > 0)
            {
                Item item = transform.GetChild(0).GetComponent<Item>();

                if (item != null && icon != null)
                {
                    icon.sprite = item.icon;
                    icon.enabled = true; // 確保顯示
                }
            }
        }
    }
}
