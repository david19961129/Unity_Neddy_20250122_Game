using UnityEngine;
using UnityEngine.UI;

namespace NEDDY
{
public class InventorySlot : MonoBehaviour
{
    public Image icon; // 道具图标
    public Button button; // 道具槽按钮

    private Item item; // 当前道具

    // 添加道具到槽
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        button.interactable = true;
    }

    // 清空槽
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    // 点击道具槽
    public void OnSlotClick()
    {
        if (item != null)
        {
            Debug.Log("使用道具：" + item.itemName);
            // 这里可以添加使用道具的逻辑
        }
    }
}
}
