using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();
    [SerializeField] private int SlotItemsCount;

    private Slot_UI selectedSlot;
    private void Start()
    {
        SelectSlot(0);
    }
    private void Update()
    {
        CheckAlphaNumericKeys();
    }
    public void SelectSlot(int index)
    {
        if (toolbarSlots.Count == SlotItemsCount)
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetHighLight(false);
            }
            selectedSlot = toolbarSlots[index];
            selectedSlot.SetHighLight(true);
            //Debug.Log("Selected Slot: " + selectedSlot.name);
        }
    }
    private void CheckAlphaNumericKeys()
    {

        for (int slotNumber = 0; slotNumber < SlotItemsCount; slotNumber++)
        {
            KeyCode keyCode = KeyCode.Alpha1 + slotNumber;

            if (Input.GetKeyDown(keyCode))
            {
                SelectSlot(slotNumber);
            }
        }

    }
}
