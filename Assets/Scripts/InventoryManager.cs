using UnityEngine;

namespace NEDDY
{
    public class InventoryManager : MonoBehaviour
    {
        public GameObject inventoryUI; // 背包 UI
        public static InventoryManager Instance;
        public Transform itemSlotsParent; // 口袋的父物件（背包 UI）

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Update()
        {
            // 按 Tab 键打开/关闭背包
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
        }

    }
}
