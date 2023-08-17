using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlotLocations : MonoBehaviour
{
    
    public static Tilemap currentTileMap;

    public Tilemap tilemap;

    public List<Plots> activePlotss;

    //WHEY DO i always forget to initiallize stuff..... fork this
    public Dictionary<Vector2Int, PlantingSpot> activePlots = new();

    private void Awake()
    {
        //meh.. this is average stuff
        if (currentTileMap == null) currentTileMap = tilemap;
    }


    private void OnEnable()
    {
        PlantingSpot.onSpotSpawn += AddPlots;
        PlantingSpot.onSpotDespawn += RemovePlots;
    }
    private void OnDisable()
    {
        PlantingSpot.onSpotSpawn -= AddPlots;
        PlantingSpot.onSpotDespawn -= RemovePlots;

    }


    
    void AddPlots(Plots plot)
    {
        activePlots.Add(plot.plotLocation, plot.plotObj);
        activePlotss.Add(plot);
        Debug.Log("Plot Added: ");
    }

    void RemovePlots(Plots plot)
    {
        activePlots.Remove(plot.plotLocation);
    }
}


//structs for ease of passing objects
[System.Serializable]
public struct Plots
{
    public Vector2Int plotLocation;
    public PlantingSpot plotObj;
}