using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject MenuContainer;
    public GameObject SettingsContainer;
    public GameObject ButtonsContainer;
    private PlayerController _playerController;
    private GameManager _GameManager;
    private bool _ShowMenu;
    private bool _ShowSettings;

    private void Start()
    {
        MenuContainer.SetActive(false);
        SettingsContainer.SetActive(false);
        ButtonsContainer.SetActive(false);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuContainer.SetActive(_ShowMenu =! _ShowMenu);
            if(MenuContainer.activeSelf == true)
            {

                Time.timeScale = 0;
                _playerController.test = false;
                ButtonsContainer.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                _playerController.test = true;
                ButtonsContainer.SetActive(false);
            }
        }
    }

    public void ContinueButton()
    {
        MenuContainer.SetActive(false);
        Time.timeScale = 1;
        _playerController.test = true;
        //ButtonsContainer.SetActive(true);
        _ShowMenu = !_ShowMenu;
    }

    public void SettingsButton()
    {
        SettingsContainer.SetActive(_ShowSettings = !_ShowSettings);
        //ButtonsContainer.SetActive(false);
    }
    
    public void LoadButton()
    {
        _GameManager.LoadGame();
        MenuContainer.SetActive(false);
        Time.timeScale = 0;
        _playerController.test = true;
        //ButtonsContainer.SetActive(true);
        _ShowMenu = !_ShowMenu;
    }
    public void SaveButton()
    {
        _GameManager.SaveGame();
        MenuContainer.SetActive(false);
        Time.timeScale = 0;
        _playerController.test = true;
        //ButtonsContainer.SetActive(true);
        _ShowMenu = !_ShowMenu;
    }
    public void ExitButton()
    {
        _GameManager.SaveGame();
        Application.Quit();
        Debug.Log("Quit Game");
        _ShowMenu = !_ShowMenu;
    }
}
