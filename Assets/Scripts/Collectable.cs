using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //Player walks into collectable,add it to player's inventory and delet from scene...

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PlayerCollectableHandler playerCollect = collision.GetComponent<PlayerCollectableHandler>();
        Debug.Log("collided");
        //if (playerCollect)
        //{
        //    playerCollect.numCollect++;
        //    Destroy(this.gameObject);
        //}
    }
}
