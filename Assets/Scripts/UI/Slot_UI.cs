using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI quantityText;
    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemImage.sprite = slot.icon;
            itemImage.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }
    public void SetEmpty()
    {
        itemImage.sprite = null;
        itemImage.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }
}
