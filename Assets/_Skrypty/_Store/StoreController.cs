using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public PlayerInfo Playerinfo;
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Gold" || other.name == "gold")
        {
            Destroy(other.gameObject);
            Playerinfo.AddMoney(100);
        }
    }
}
