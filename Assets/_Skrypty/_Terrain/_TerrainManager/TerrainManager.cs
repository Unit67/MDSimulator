using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public Terrain _terrain;

    public GameObject Player;
    public int yRes;
    public int xRes;
    private void Start()
    {
        RaycastHit Hit;
        Ray Ray;
        if(Physics.Raycast(transform.position,-transform.up,out Hit, 10))
        {
            Debug.DrawLine(transform.position, Hit.point,Color.black);
        }
        //EditTerrainHeight(500,500, 0.001f);
    }
    private void Update()
    {
        //_terrain = Terrain.activeTerrain;
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
        yRes = _terrain.terrainData.heightmapHeight;
        xRes = _terrain.terrainData.heightmapWidth;
        Debug.Log(xRes + "," + yRes);

        float[,] heights = _terrain.terrainData.GetHeights(0, 0, xRes, yRes);

        heights[Z, X] = Y;
        
        _terrain.terrainData.SetHeights(0,0,heights);
    }
}
