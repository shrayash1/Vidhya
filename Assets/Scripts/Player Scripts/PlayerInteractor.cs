using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject targetposition;
    private GameObject targetedInteractableObject;
    private PlantingSpot plantingSpot;
    [SerializeField] private PlantSO plantSO;

    private RaycastHit2D hitObject;
    public bool canInteract;

    private void Start()
    {
        playerInput.OnInteractionPerformed += PlayerInput_OnInteractionPerformed;
    }

    private void PlayerInput_OnInteractionPerformed()
    {
        if (canInteract)
        {
            Debug.Log("planted object");
            plantingSpot.Interact(plantSO);
        }
    }

    private void Update()
    {
        canInteract = false;

        hitObject = Physics2D.Raycast(transform.position, playerInput.aimDirection, rayDistance, interactableLayer);
        if (hitObject.collider != null)
        {
            GameObject targetObject = hitObject.collider.gameObject;
            if (targetObject.TryGetComponent(out PlantingSpot plantingSpotObject))
            {
                plantingSpot = plantingSpotObject;
                canInteract = true;
            }
        }
        targetposition.transform.position = transform.position + (Vector3)playerInput.aimDirection;
        
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.black;
        //Gizmos.DrawLine(transform.position,targetposition.transform.position);
    }
}
