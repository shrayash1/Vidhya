using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantingSpot : MonoBehaviour
{
    public GameObject OverLay;

    [SerializeField] private Tilemap activeTileMap;

    Plots thisPlot;

    //create an action for the spot spawnning message
    public static event Action<Plots> onSpotSpawn;
    public static event Action<Plots> onSpotDespawn;

    private void OnEnable()
    {
        //typcasting here.. since.. worldtocell returns vec3int... but we dont need the z value
        Vector2Int temporary = (Vector2Int) activeTileMap.WorldToCell(this.transform.position);

        //create a structure for to pass into the event
        thisPlot = new Plots
        {
            plotLocation = temporary,
            plotObj = this
        };

        //trigger the spawnning
        onSpotSpawn?.Invoke(thisPlot);
    }

    private void OnDisable()
    {
        //This could be analysed further for reducing resource cost
        onSpotDespawn?.Invoke(thisPlot);
    }


    /// <summary>
    /// Aysh dais code blocks from below here... with some of mine just for the lolz
    /// </summary>

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
