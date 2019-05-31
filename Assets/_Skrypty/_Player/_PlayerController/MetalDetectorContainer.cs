using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetectorContainer : MonoBehaviour
{
    public Hand Hand;
    public Terrain _Terrain;

    private void Start()
    {
        _Terrain = Terrain.activeTerrain;
        Hand = GameObject.Find("Main Camera").GetComponent<Hand>();
    }
    private void OnTriggerStay(Collider MetalDetector)
    {
        if(MetalDetector.gameObject.name == "MetalDetector" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("MetalDetector new parent");
            Hand.NewParent(_Terrain.gameObject, MetalDetector.gameObject);
        }
    }
}
