using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile interactedTile;

    [SerializeField] private Tile hiddenInteractableTiles;
    void Start()
    {
        playerInput.OnInteractionPerformed += PlayerInput_OnInteractionPerformed;
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            if(tile != null)
            {
                interactableMap.SetTile(position, hiddenInteractableTiles);
            }
        }
    }

    private void PlayerInput_OnInteractionPerformed()
    {
        Transform player = playerInput.transform;
        Vector3Int position = new Vector3Int((int)player.position.x,(int)player.position.y,0);
        int offX=0, offY=0;
        if (playerInput.currentLookDirection == PlayerInput.LookDirection.Up)
        {
            offX = 0;
            offY = 0;
        }
        if (playerInput.currentLookDirection == PlayerInput.LookDirection.Down)
        {
            offX = 0;
            offY = -2;
        }
        if (playerInput.currentLookDirection == PlayerInput.LookDirection.Left)
        {
            offX = -1;
            offY = -1;
        }
        if (playerInput.currentLookDirection == PlayerInput.LookDirection.Right)
        {
            offX = 1;
            offY = -1;
        }
        Vector3Int spawnOffset = new Vector3Int(offX,offY, 0);
        if (IsInteractable(position+spawnOffset))
        {
            Debug.Log("Interacted: "+position);
            SetInteracted(position+ spawnOffset);
        }
    }
    private bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "Interactable")
            {
                return true;
            }
        }
        return false;
    }
    private void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }
}
