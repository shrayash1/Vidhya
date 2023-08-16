using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantationInteractionHandler : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] MovementScript player;
    [SerializeField] PlotLocations plotLocation;
    [SerializeField] PlantSO plantSO;
    GameObject activeOverLay;

    [SerializeField]
    Tilemap activeTilemap;
    //typecasting again
    Vector2Int playerGridPos => (Vector2Int) activeTilemap.WorldToCell(player.gameObject.transform.position);
     



    private void OnEnable()
    {
        input.OnInteractionPerformed += TryInteraction;
    }

    private void Update()
    {
        //this is some weird stuff .. check late update for clarification
       // if(activeOverLay != null) { activeOverLay.SetActive(false); }

    }

    private void LateUpdate()
    {
        //Vector2Int checkPosition = ReturnCheckPos();
        //if (plotLocation.activePlots.ContainsKey(checkPosition) is true)
        //{
        //    activeOverLay = plotLocation.activePlots[checkPosition].OverLay;
        //}
        //else
        //{
        //    activeOverLay = null;
        //}
        //if (activeOverLay != null)
        //{
        //    activeOverLay.SetActive(true);
        //}
    }

    void TryInteraction()
    {
        Debug.Log("interaction");


        Vector2Int checkPosition = ReturnCheckPos();

        //if there is no platobj at check position... this logic is skipped
        if(plotLocation.activePlots.ContainsKey(checkPosition))
        {
            Debug.Log("interaction");
            plotLocation.activePlots[checkPosition].Interact(plantSO);
        }
       

    }

    

    Vector2Int ReturnCheckPos()
    {
        Vector2Int temp = playerGridPos;

        switch (player.GetPlayerDirection())
        {
            case FacingDirection.Left:
                temp.x -= 1;
                break;
            case FacingDirection.Right:
                temp.x += 1;
                break;
            case FacingDirection.Up:
                temp.y += 1;
                break;
            case FacingDirection.Down:
                temp.y -= 1;
                break;
            
        }

        return temp;

       
    }

}
