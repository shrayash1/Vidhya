using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSpot : MonoBehaviour
{
    public enum PlantStatus
    {
        Empty,
        Planted
    }
    [SerializeField] private SpriteRenderer spriteRenderer;
    public PlantSO plantInfo;
    public PlantStatus currentPlantStatus;
    

    private int plantedIndex;

    private void Start()
    {
        currentPlantStatus = PlantStatus.Empty;
    }

    public void Interact(PlantSO plantSO)
    {
        switch (currentPlantStatus)
        {
            case PlantStatus.Empty:
                plantInfo = plantSO;
                PlantObject();
                break;
            
            case PlantStatus.Planted:
                if (plantedIndex == plantInfo.plantStages.Length)
                {
                    PickUpPlant();
                }
                break;

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ProgressPlant();
        }
    }

    private void PlantObject()
    {
        spriteRenderer.sprite = plantInfo.plantStages[0];
    }
    private void PickUpPlant()
    {
        throw new NotImplementedException();
    }
    private void ProgressPlant()
    {
        if(plantInfo == null)
            return;
        plantedIndex++;
        spriteRenderer.sprite = plantInfo.plantStages[plantedIndex];
    }
}
