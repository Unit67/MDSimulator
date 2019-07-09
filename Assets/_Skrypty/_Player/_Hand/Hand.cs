using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Hand : MonoBehaviour
{
    public RaycastHit hit;
    public KeyCode FunctionKey = KeyCode.F;
    public GameObject MetalDetector;
    public GameObject MetalDetectorContainer;
    public bool _MetalDetectorHand;
    public Terrain _Terrain;
    public TerrainManager terrainManager;
    private string _ColliderName;
    
    void Start()
    {
        MetalDetector = GameObject.Find("MetalDetector");
        _Terrain = Terrain.activeTerrain;
    }

    void Update()
    {
        #region hit collider detection region
        if(Physics.Raycast(transform.position,transform.forward, out hit,10))
        {
            Debug.DrawLine(transform.position,hit.point,Color.green);
                _ColliderName = hit.collider.name;
                if (hit.collider.name == "MetalDetector" && Input.GetKeyDown(FunctionKey))
                {
                    _MetalDetectorHand = true;
                }
                else if(_MetalDetectorHand == true && Input.GetKeyDown(FunctionKey))
                {
                    _MetalDetectorHand = false;
                }

                if (_ColliderName == "Terrain")
                {

                    Vector3 Point;
                    Point = hit.point;
                    if (Input.GetMouseButton(0))
                    {
                        Debug.Log("Point X: " + Point.x + " Point Z: " + Point.z);
                        terrainManager.EditTerrainHeight((int)Point.x,(int)Point.z,-0.010f);
                    }
                }
                Debug.Log(hit.collider.name);
        }

        switch (_MetalDetectorHand)
        
        {
                case true:
                {
                    NewParent(MetalDetectorContainer,MetalDetector);
                    MetalDetector.transform.localPosition = new Vector3(0,0,0);
                }
                    break;
                case false:
                {
                    NewParent(_Terrain.gameObject,MetalDetector);
                }
                    break;
                
        }
        #endregion
        
        
    }
    public void NewParent(GameObject ObParent,GameObject ObChild)
    {
        //ObChild.transform.SetParent(ObParent.transform, true);
        ObChild.transform.parent = ObParent.transform;
        ObChild.GetComponent<BoxCollider>().isTrigger = true;
        //ObChild.GetComponent<Rigidbody>().useGravity = false;
        //NewParentIsParent = true;
    }
}
