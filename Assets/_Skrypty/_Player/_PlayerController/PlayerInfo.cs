using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInfo : MonoBehaviour
{
    public Text MoneyText;
    public int Money = 0;
    /*public enum PlayerInfoEnum
    {
        Health = 1,
        Desire,
        Money = 100
    }*/
    public void AddMoney(int AddMoney)
    {
        Money += AddMoney;
        MoneyText.text = "Money: " + Money;
        Debug.Log("money added: " + AddMoney);
    }
}
