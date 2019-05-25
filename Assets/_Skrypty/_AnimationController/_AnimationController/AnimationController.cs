using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator Anim;
    public TrunkInfo TrunkInfo;
    private void Update()
    {
        Ray ray;
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,10))
        {
            Debug.DrawLine(transform.position, hit.point,Color.cyan);
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.name == "Trunk")
            {
                if (!TrunkInfo.GetTrunkOpen())
                {
                    Anim.SetTrigger("Open");
                    TrunkInfo.SetTrunkOpen(true);
                }
                else if (TrunkInfo.GetTrunkOpen())
                {
                    Anim.SetTrigger("Close");
                    TrunkInfo.SetTrunkOpen(false);
                }
                //Anim["TrunkAnim"].layer = 11;
            }
        }
    }
}
