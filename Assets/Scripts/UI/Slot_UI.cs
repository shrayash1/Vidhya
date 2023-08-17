using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI quantityText;
    public Button button;
    [SerializeField]Iventory_UI inventoryUI;
    [SerializeField] int ItemIndex;
    private void Awake()
    {
        inventoryUI = FindAnyObjectByType<Iventory_UI>();
        button.onClick.AddListener(RemoveItem);
    }
    void RemoveItem()
    {
        inventoryUI.Remove(ItemIndex);
    }
    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemImage.sprite = slot.icon;
            itemImage.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }
    public void GetItemIndex(int i)
    {
        ItemIndex = i;
    }
    public void SetEmpty()
    {
        itemImage.sprite = null;
        itemImage.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }
}
