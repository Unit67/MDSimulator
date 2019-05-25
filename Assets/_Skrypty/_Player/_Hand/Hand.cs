using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool NewParentIsParent = false;
    public bool MetalDetectorDetected = false;
    public GameObject Player;
    public MetalDetector MetalDetector;
    public EQController EQController;
    private GameObject _MetalDetectorContainer;
    private GameObject _MetalDetector;
    private GameObject _GoldContainer;
    private void Start()
    {
        try
        {
            if(_MetalDetectorContainer == null)
            {
                _MetalDetectorContainer = GameObject.Find("MetalDetector container");
            }
            if (_MetalDetector == null)
            {
                _MetalDetector = GameObject.Find("MetalDetector");
            }
            if(_GoldContainer == null)
            {
                _GoldContainer = GameObject.Find("Gold Container");
            }
        }
        catch
        {
            _MetalDetectorContainer = null;
        }
    }

    private void Update()
    {
        RaycastHit hit;
        RaycastHit hit2;
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10, 9))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
            if(hit.collider.name == "Gold" || hit.collider.name == "gold")
            {
                if(Input.GetMouseButton(1))
                {
                    //for (int i = 0; i <= 1; i++)
                    //{
                    EQController.ItemsGold.Add(hit.collider.gameObject);
                    NewParent(_GoldContainer, hit.collider.gameObject);
                    hit.collider.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                        
                    //}
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (hit.collider.gameObject.name == "MetalDetector" || hit.collider.gameObject.name == "metaldetector")
                    NewParentIsParent = !NewParentIsParent;
            }
            if (hit.collider.name == "MetalDetector")
            {
                MetalDetectorDetected = true;
            }
            else
            {
                MetalDetectorDetected = false;
            }
            if (hit.collider.gameObject.name == null)
            {
                //Debug.Log("Set new parent");
            }
            else
            {
                if(hit.collider.gameObject.name == "MetalDetector")
                {
                    if(Input.GetKeyDown(KeyCode.F))
                    {
                        NewParent(this.gameObject.transform.parent.gameObject, _MetalDetector);
                        hit.collider.gameObject.transform.localPosition = new Vector3(0.54f, 0.025f, 1.344f);
                    }
                }
            }
        }
        if(MetalDetectorDetected == false)
        {
            if(Physics.Raycast(transform.position,transform.forward,out hit2,10))
            {
                int _Xpoint, _Zpoint;
                //_Xpoint = int.Parse(hit2.point.x.ToString());
                //_Zpoint = int.Parse(hit2.point.z.ToString());
                _Xpoint = (int)hit2.point.x;
                _Zpoint = (int)hit2.point.z;
                //Debug.Log("Xpoint: " + _Xpoint + "|" + "Zpoint: " + _Zpoint);
                if (MetalDetectorDetected == false)
                {
                    if (Input.GetMouseButton(0))
                    {
                        Debug.Log("MouseButton 0 is pressd");
                        Debug.Log("_Zpoint: " + _Zpoint + "_Xpoint: " + _Xpoint);
                        //if(hit2.collider.name != "Terrain")
                        GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().EditTerrainHeight(_Zpoint, _Xpoint, -0.001f);
                    }
                    Debug.DrawLine(ray2.origin, hit2.point, Color.green);
                }
            }
        }
        
        switch (NewParentIsParent)
        {
            case true:
                {
                    if(hit.collider.gameObject.name == null)
                    {
                    }
                    else
                    {
                        if(hit.collider.gameObject.name == "MetalDetector")
                        {
                            NewParent(this.gameObject.transform.parent.gameObject, _MetalDetector);
                            hit.collider.gameObject.transform.localPosition = new Vector3(0.54f, 0.025f, 1.344f);
                        }
                    }
                }
                break;
            case false:
                {
                    if(Input.GetKeyDown(KeyCode.F))
                    {
                        if(hit.collider.name != "Terrain")
                        {
                            NewParent(null, _MetalDetector);
                        }
                    }
                }
                break;
        }
        switch(MetalDetectorDetected)
        {
            case true:
                {
                    if (Input.GetMouseButton(0))
                    {
                        NewParent(this.gameObject, _MetalDetector);
                        //NewParentIsParent = true;
                    }
                }
                break;
            case false:
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (_MetalDetector != null)
                        {
                            if (_MetalDetectorContainer != null)
                            {
                                Debug.Log("NewParen MetalDetector");
                                NewParent(_MetalDetectorContainer.gameObject, _MetalDetector);
                                _MetalDetector.transform.localPosition = new Vector3(0, 0, 0);
                                _MetalDetector.transform.localEulerAngles = new Vector3(0, 90, 0);
                            }
                            else if (_MetalDetectorContainer == null)
                            {
                                Debug.Log("_MetalDetectorContainer == null");
                            }
                        }
                        else if (_MetalDetector == null)
                        {
                            Debug.Log("_MetalDetector == null");
                        }
                    }
                }
                break;
        }
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
