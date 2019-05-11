using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool NewParentIsParent = false;
    public GameObject Player;
    private void Update()
    {
        RaycastHit hit;
        RaycastHit hit2;
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(transform.position,transform.forward, out hit, 10,9))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
            if(hit.collider.name == "MetalDetector")
            {
                if (Input.GetMouseButton(0))
                {
                    NewParent(this.gameObject, hit.collider.gameObject);
                    NewParentIsParent = true;
                }
                //Debug.Log("Test");
            }
        }
        if(Physics.Raycast(transform.position,transform.forward,out hit2, 10))
        {
            int _Xpoint, _Zpoint;
            //_Xpoint = int.Parse(hit2.point.x.ToString());
            //_Zpoint = int.Parse(hit2.point.z.ToString());
            _Xpoint = (int)hit2.point.x;
            _Zpoint = (int)hit2.point.z;
            Debug.Log("Xpoint: " + _Xpoint + "|" + "Zpoint: " + _Zpoint);
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("MouseButton 0 is pressd");
                GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().EditTerrainHeight(_Zpoint, _Xpoint, -0.001f);
            }
            Debug.DrawLine(ray2.origin, hit2.point, Color.green);
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
    }
    void NewParent(GameObject ObParent,GameObject ObChild)
    {
        //ObChild.transform.SetParent(ObParent.transform, true);
        ObChild.transform.parent = ObParent.transform;
        ObChild.GetComponent<BoxCollider>().isTrigger = true;
        ObChild.GetComponent<Rigidbody>().useGravity = false;
        NewParentIsParent = true;
    }
}
