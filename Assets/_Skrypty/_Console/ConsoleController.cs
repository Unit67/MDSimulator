using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConsoleController : MonoBehaviour
{
    public GameObject ConsoleContainer;
    public InputField InputField;
    public Text ConsoleText;
    bool _ShowConsole;
    int X, Y, Z;

    private void Update()
    {
        ConsoleContainer.SetActive(_ShowConsole);
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _ShowConsole = !_ShowConsole;
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            _ShowConsole = !_ShowConsole;
            if(ConsoleContainer.activeSelf == true)
            {
                Debug.Log("ConsoleContainer == true");

                int X, Y, Z;
                
            }
        }
            
    }


    public void EnterButton()
    {
        //InputField.text.Insert(1, "test");
    }
}
