using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool NewParentIsParent = false;
    private bool _MetalDetectorDetected = false;
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
            if (hit.collider.name == "MetalDetector")
            {
                _MetalDetectorDetected = true;
            }
            else
            {
                _MetalDetectorDetected = false;
            }
        }
        if(Physics.Raycast(transform.position,transform.forward,out hit2,10))
        {
            int _Xpoint, _Zpoint;
            //_Xpoint = int.Parse(hit2.point.x.ToString());
            //_Zpoint = int.Parse(hit2.point.z.ToString());
            _Xpoint = (int)hit2.point.x;
            _Zpoint = (int)hit2.point.z;
            //Debug.Log("Xpoint: " + _Xpoint + "|" + "Zpoint: " + _Zpoint);
            if (_MetalDetectorDetected == false)
            {
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("MouseButton 0 is pressd");

                    //if(hit2.collider.name != "Terrain")
                    GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().EditTerrainHeight(_Zpoint, _Xpoint, -0.001f);
                }
                Debug.DrawLine(ray2.origin, hit2.point, Color.green);
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            NewParentIsParent = !NewParentIsParent;
        }

        switch (NewParentIsParent)
        {
            case true:
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        hit.collider.gameObject.transform.position = new Vector3(Player.transform.position.x + 0.54f, Player.transform.position.y + 0.025f, Player.transform.position.z + 1.344f);
                        NewParent(this.gameObject.transform.parent.gameObject, hit.collider.gameObject);
                    }
                }
                break;
            case false:
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        NewParent(GameObject.Find("Terrain"), GameObject.Find("MetalDetector"));

                    }
                }
                break;
        }
        switch(_MetalDetectorDetected)
        {
            case true:
                {
                    if (Input.GetMouseButton(0))
                    {
                        NewParent(this.gameObject, hit.collider.gameObject);
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
    void NewParent(GameObject ObParent,GameObject ObChild)
    {
        //ObChild.transform.SetParent(ObParent.transform, true);
        ObChild.transform.parent = ObParent.transform;
        ObChild.GetComponent<BoxCollider>().isTrigger = true;
        //ObChild.GetComponent<Rigidbody>().useGravity = false;
        //NewParentIsParent = true;
    }
}
