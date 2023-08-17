using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel,slotParent,slotPrefab;
    public PlayerCollectableHandler playerCollectables;
    public List<Slot_UI> slots = new List<Slot_UI>();
    private void Awake()
    {
        //InstantiateSlots();
        //AddSlotsFromParent(slotParent);
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
        if(slots.Count != playerCollectables.inventory.slots.Count)
        {
            InstantiateSlots();
        }
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Refresh()
    {
        if(slots.Count >= playerCollectables.inventory.slots.Count)
        {
            Debug.Log("Opened");
            for(int i = 0; i < slots.Count; i++)
            {
                if (playerCollectables.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(playerCollectables.inventory.slots[i]);
                    slots[i].GetItemIndex(i);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
  
    public void Remove(int slotID)
    {
        Collectable itemToDrop = GameManager.instance.itemManager.GetItemByType(playerCollectables.inventory.slots[slotID].type);
        if (itemToDrop != null)
        {
            playerCollectables.DropItem(itemToDrop);
            playerCollectables.inventory.Remove(slotID);
            Refresh();
        }
    }
    private void InstantiateSlots()
    {
        for(int i=0;i< playerCollectables.inventory.slots.Count; i++)
        {
            Instantiate(slotPrefab,slotParent.transform);
        }
        AddSlotsFromParent(slotParent);
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
