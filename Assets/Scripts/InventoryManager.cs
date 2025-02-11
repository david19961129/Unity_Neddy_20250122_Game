using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 单例模式

    public List<Item> items = new List<Item>(); // 背包中的道具列表
    public Transform itemSlotsParent; // 道具槽的父对象
    public GameObject inventoryUI; // 背包 UI

    private void Awake()
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

    // 添加道具到背包
    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        UpdateUI();
    }

    // 从背包移除道具
    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
        UpdateUI();
    }

    // 更新背包 UI
    private void UpdateUI()
    {
        // 清空所有道具槽
        foreach (Transform slot in itemSlotsParent)
        {
            slot.GetComponent<Image>().sprite = null;
            slot.GetComponent<Image>().enabled = false;
        }

        // 更新道具槽
        for (int i = 0; i < items.Count; i++)
        {
            itemSlotsParent.GetChild(i).GetComponent<Image>().sprite = items[i].icon;
            itemSlotsParent.GetChild(i).GetComponent<Image>().enabled = true;
        }
    }
}