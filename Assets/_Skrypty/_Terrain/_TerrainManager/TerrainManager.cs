using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public Terrain _terrain;

    private void Start()
    {
        _terrain = Terrain.activeTerrain;
        EditTerrainHeight(0,0,0);
    }

    public void EditTerrainHeight(int X, int Z, int Y)
    {
        int xRes = _terrain.terrainData.heightmapHeight;
        int yRes = _terrain.terrainData.heightmapWidth;

        int xBase = 125;
        int yBase = 125;

        float[,] heights = _terrain.terrainData.GetHeights(xBase, yBase, 125, 125);

        heights[Z, X] = Y;

        _terrain.terrainData.SetHeights(xBase, yBase, heights);
    }
}
