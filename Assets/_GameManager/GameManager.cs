using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public PlayerInfo PlayerInfo;
    private void OnApplicationQuit()
    {
        SaveGame();
        //Application.CancelQuit();
    }

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        try
        {
            LoadGame();
        }
        catch(Exception Ex)
        {
            Debug.LogError(Ex);
        }
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        PlayerInfo.Money = data.Money;
        PlayerInfo.Desire = data.Des;

        Vector3 position;
        position.x = data.Pos[0];
        position.y = data.Pos[1];
        position.z = data.Pos[2];
        Player.PlayerTeleport(position.x, position.y, position.z);

    }
    public void SaveGame()
    {
        SaveSystem.SavePlayer(Player);
    }
}
