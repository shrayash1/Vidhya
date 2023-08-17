using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel,Slots;
    public PlayerCollectableHandler playerCollectables;
    public List<Slot_UI> slots = new List<Slot_UI>();
    private void Awake()
    {
        AddSlotsFromParent(Slots);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }
    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Setup()
    {
        if(slots.Count >= playerCollectables.inventory.slots.Count)
        {
            Debug.Log("Opened");
            for(int i = 0; i < slots.Count; i++)
            {
                if (playerCollectables.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(playerCollectables.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
    private void AddSlotsFromParent(GameObject parent)
    {
        Slot_UI[] slotComponents = parent.GetComponentsInChildren<Slot_UI>();

        foreach (Slot_UI slot in slotComponents)
        {
            slots.Add(slot);
        }
    }
}
