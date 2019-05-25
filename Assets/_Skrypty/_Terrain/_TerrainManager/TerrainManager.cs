using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public Terrain _terrain;
    public int xBase=0 ,yBase=0;
    private void Start()
    {
        RaycastHit Hit;
        Ray Ray;
        if(Physics.Raycast(transform.position,-transform.up,out Hit, 10))
        {
            Debug.DrawLine(transform.position, Hit.point,Color.black);
        }
        EditTerrainHeight(500,500, 0.001f);
    }
    private void Update()
    {
        _terrain = Terrain.activeTerrain;
        //if (Camera.main.GetComponent<Hand>().NewParentIsParent == false)
        //{
         //   Terrain.activeTerrain.gameObject.layer = 0;
        //}
        //else
        //{
            Terrain.activeTerrain.gameObject.layer = 9;
        //}
        //xBase = -(int)GameObject.Find("Player").transform.position.x;
        //yBase = (int)GameObject.Find("Player").transform.position.y;
    }

    public void EditTerrainHeight(int X, int Z, float Y)
    {
        Debug.Log("Edit terrain height");
        //int xBase = 0;
        //int yBase = 0;
        /*xBase = _terrain.terrainData.heightmapWidth;
        yBase = _terrain.terrainData.heightmapHeight;

        float[,] heights =_terrain.terrainData.GetHeights(xBase, yBase, 152, 152);
        heights[X,Z] = Y;

        _terrain.terrainData.SetHeights(xBase, yBase, heights);
        */
        if(_terrain != null)
        {
            int xRes = _terrain.terrainData.heightmapWidth;
            int yRes = _terrain.terrainData.heightmapHeight;

            float[,] heights = _terrain.terrainData.GetHeights(0, 0, xRes, yRes);

            heights[X, Z] = Y;

            _terrain.terrainData.SetHeights(0, 0, heights);
        }
        else if(_terrain == null)
        {
            Debug.LogError("terrain == null");
        }
    }
}
