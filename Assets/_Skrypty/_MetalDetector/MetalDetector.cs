using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    RaycastHit Hit;
    Ray ray;
    public string HitColliderName;
    public Light PointLight;
    public string[] GoldList;
    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, out Hit, 10, 9))
        {
            Debug.DrawLine(transform.position, Hit.point, Color.green);
            HitColliderName = Hit.collider.gameObject.name;
        }
        else
        {
            HitColliderName = "";
        }
        for (int i =0; i <= GoldList.Length; i++)
        {
            if (i < GoldList.Length)
            {
                if (HitColliderName == GoldList[i])
                {
                    PointLight.range = 0.6f;
                    //Debug.Log(GoldList[i]);
                    break;
                }
                else
                {
                    PointLight.range = 0.0f;
                }
            }
        }
    }
}
