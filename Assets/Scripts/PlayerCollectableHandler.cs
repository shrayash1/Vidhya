using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectableHandler : MonoBehaviour
{
    private MovementScript pMovement;
    [SerializeField] [Range(0f, 30f)] private int inventorySize=15;
    public Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory(inventorySize);
        pMovement = GetComponent<MovementScript>();
    }
    private void FixedUpdate()
    {
        if (pMovement.ReturnCollectable(transform.position)!=null)
        {
            Collectable collectable = pMovement.ReturnCollectable(transform.position).GetComponent<Collectable>();
            inventory.Add(collectable);
            Destroy(collectable.gameObject);
        }
    }
}
