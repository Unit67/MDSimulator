using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInfo : MonoBehaviour
{
    public Text MoneyText;
    public Text DesireText;
    public int TimeToDeductThirst = 600;
    public int Money;
    public int Desire;
    private float _TimeLeft;
    public int _IntTimeLeft;
    /*public enum PlayerInfoEnum
    {
        Health = 1,
        Desire,
        Money = 100
    }*/

    private void Start()
    {
        //Desire = 100;
    }
    private void Update()
    {
        DesireText.text = "Desire: " + Desire;
        _TimeLeft += Time.deltaTime;
        _IntTimeLeft = (int)_TimeLeft;
        //Debug.Log("IntTimeLeft: " + _IntTimeLeft);
        if(_IntTimeLeft == 600)
        {
            _IntTimeLeft = 0;
            _TimeLeft = 0;
            if(Desire > -1)
            {
                Desire -= 1;
            }
            else
            {
                Desire = 0;
            }
        }
    }
    public void AddMoney(int AddMoney)
    {
        Money += AddMoney;
        MoneyText.text = "Money: " + Money;
        Debug.Log("money added: " + AddMoney);
    }
    public void SetMoney(int Money)
    {
        this.Money = Money;   
    }
    public void EditDesire(int desire)
    {
        Desire = desire;
    }
    public int GetDesire()
    {
        return Desire;
    }
    public int GetMoney()
    {
        return Money;
    }
}
