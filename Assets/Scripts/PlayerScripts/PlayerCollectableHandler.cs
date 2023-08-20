using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectableHandler : MonoBehaviour
{
    private MovementScript pMovement;
    [SerializeField] [Range(0f, 32f)] private int inventorySize=15;
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
            if (collectable.item != null)
            {
                inventory.Add(collectable.item);
                Destroy(collectable.gameObject);
            }
            
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;

        float randX = Random.Range(-2f, 2f);
        float randY = Random.Range(-2f, 2f);

        Vector2 spawnOffset = new Vector2(randX, randY).normalized;

        Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
    }
}
