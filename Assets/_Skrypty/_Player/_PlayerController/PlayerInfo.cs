using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInfo : MonoBehaviour
{
    public Text MoneyText;
    public int Money;
    /*public enum PlayerInfoEnum
    {
        Health = 1,
        Desire,
        Money = 100
    }*/

    private void Update()
    {
        MoneyText.text = "Money: " + Money;
    }

}
