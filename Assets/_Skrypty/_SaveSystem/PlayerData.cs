
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class PlayerData
{
    //public int Hp;
    public int Money;
    public int Des;
    public float[] Pos;
    public PlayerData (PlayerController player)
    {
        PlayerInfo playerInfo = new PlayerInfo();
        Des = player.Des;
        Money = player.Money;



        Pos = new float[3];
        Pos[0] = player.transform.position.x;
        Pos[1] = player.transform.position.y;
        Pos[2] = player.transform.position.z;
    }
}
