using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Hand Hand;
    public AnimationController AnimControl;
    private PlayerInfo _PlayerInfo;
    private WaterInfo _WaterInfo;
    public int CleanWaterDesireLevel = 40;
    public int DirtyWaterDesireLevel = -40;
    public int SweetWaterDesireLevel = 40;
    public int SaltWaterDesireLevel = -90;

    private void Start()
    {
        _WaterInfo = this.gameObject.GetComponent<WaterInfo>();
        _PlayerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        if(Hand.hit.collider.name != null)
        {
            if(Hand.hit.collider.name == "BottledWater")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    AnimControl.Anim.SetTrigger("TrunStopAnim");
                    if (_WaterInfo.WaterType == WaterInfo.Water.CleanWater)
                    {
                        Debug.Log("Clean Water");
                        if (_PlayerInfo != null)
                        {
                            if(_PlayerInfo.GetDesire() != 100)
                            {
                                _PlayerInfo.EditDesire(_PlayerInfo.GetDesire() + CleanWaterDesireLevel);
                            }
                            GameObject.Destroy(Hand.hit.collider.gameObject);
                        }
                        else
                        {
                            Debug.LogError("_PlayerInfo == null");
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Hand.hit.collider.name == null");
        }
    }
}
