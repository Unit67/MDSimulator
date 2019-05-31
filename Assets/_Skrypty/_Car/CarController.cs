using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public PlayerController PlayerController;
    public PlayerInfo playerInfo;
    public GameObject Player;
    public Vector3 TeleportPoint;
    public GameObject TeleportContainer;
    public Hand Hand;
    public int Money;
    public int Des;
    private void Start()
    {
        TeleportPoint = TeleportContainer.transform.position;
    }

    private void Update()
    {
        if (Hand.hit.collider.name != null)
        {
            if(Hand.hit.collider.name == "Door")
            {
                Debug.Log("Door Detected");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E is pressed");
                    TeleportToStore();
                }
            }    
        }
        
        Money = playerInfo.Money;
        Des = playerInfo.Desire;
    }

    void TeleportToStore()
    {

        PlayerController.test = false;
        PlayerController.PlayerTeleport(TeleportPoint.x, TeleportPoint.y, TeleportPoint.z);
        //Player.transform.position = new Vector3(TeleportPoint.x, TeleportPoint.y, TeleportPoint.z);
        if(Player.transform.position == TeleportPoint)
        {
            PlayerController.test = true;
        }
        Debug.Log("Teleport To Store");
    }
}
