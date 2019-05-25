using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
{
    public InputField XInputField,YInputField,ZInputField;
    public Text ErrorText;
    public GameObject TeleportContainer;
    public GameObject _Player;
    private float _X, _Y, _Z;
    private bool _TeleportContainerShow = false;
    private void Start()
    {
        _Player = GameObject.Find("Player");
        TeleportContainer.SetActive(false);
    }

    private void Update()
    {
        try
        {
            float.TryParse(XInputField.text,out _X);
            float.TryParse(YInputField.text, out _Y);
            float.TryParse(ZInputField.text, out _Z);
        }
        catch(Exception Ex)
        {
            ErrorText.text = "Error: " + Ex.Message;
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            _TeleportContainerShow = !_TeleportContainerShow;
            TeleportContainer.SetActive(_TeleportContainerShow);
        }
    }

    public void EnterButton()
    {
        if(_Player != null)
        {
            _Player.transform.position = new Vector3(_X, _Y, _Z);
        }
    }
}
