using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    private void Awake()
    {
        icon = GetComponent<SpriteRenderer>().sprite;
    }
}
public enum CollectableType
{
    NONE,
    PUMPKIN_SEED,
    POTATO_SEED,
    CARROT_SEED,
    TOMATO_SEED,
    CHILLY_SEED
}
