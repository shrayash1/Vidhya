using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    [HideInInspector]public Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
    }
}
