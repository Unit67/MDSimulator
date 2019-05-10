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
