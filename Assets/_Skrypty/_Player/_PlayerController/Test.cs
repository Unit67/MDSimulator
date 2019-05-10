using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(transform.position,transform.eulerAngles,out hit,100))
        {
            Debug.Log("point X: " + hit.point.x + "Z:" + hit.point.z);
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
        }
    }
}
