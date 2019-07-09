using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float MaxJump = 10;
    public bool Dead = false;
    private float _CamSpeedH = 2.0f;
    private float _CamSpeedV = 2.0f;
    private float _yaw = 0.0f;
    private float _pitch = 0.0f;
    private float _Gravity = 9.0f;
    private float _VSpeed;
    private float _TimeLeft;
    private int _IntTimeLeft;
    public Toggle DeadToggle;
    public int _TimeLeftSpeed = 5;
    public GameObject camera;
    public Terrain Terrain;
    public CharacterController CharacterController;
    public PlayerInfo Playerinfo;
    public GameObject DeadContainer;
    public EQController EQController;
    public TextMeshProUGUI TextBlueScreen;
    public TextMeshProUGUI ViewFinderText;
    public Hand Hand;
    public bool test = true;
    public int Money;
    public int Des;
    private void Start()
    {
        CharacterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    private void Update()
    {
        Money = Playerinfo.Money;
        Des = Playerinfo.Desire;

        if(DeadToggle.isOn == true)
        {
            Dead = true;
            DeadToggle.isOn = false;
        }
        #region MoveRegion
        if (test == true)
        {
            Vector3 _Move;
            if (Input.GetAxis("JoyVertical") != 0)
            {
                _Move = transform.forward * Input.GetAxis("JoyVertical") * MoveSpeed;   
            }
            else
            {
                _Move = transform.forward * Input.GetAxis("Vertical") * MoveSpeed;  
            }
            _VSpeed -= _Gravity * Time.deltaTime;
            _Move.y = _VSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * MaxJump * Time.deltaTime, ForceMode.Force);
            }
            CharacterController.Move(_Move * Time.deltaTime);
            if (Input.GetAxis("JoyHorizontal") != 0)
            {
                CharacterController.Move(transform.right * Input.GetAxis("JoyHorizontal") * MoveSpeed * Time.deltaTime);   
            }
            else
            {
                CharacterController.Move(transform.right * Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime);   
            }

            #endregion
            #region Camera Rotation

            if (Input.GetAxis("JoyRightHorizontal") != 0 || Input.GetAxis("JoyRightVertical") != 0)
            {
                _yaw += _CamSpeedH * Input.GetAxis("JoyRightHorizontal");
                _pitch -= _CamSpeedV * Input.GetAxis("JoyRightVertical");
            }
            else
            {
                _yaw += _CamSpeedH * Input.GetAxis("Mouse X");
                _pitch -= _CamSpeedV * Input.GetAxis("Mouse Y");

            }
            
            camera.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
            CharacterController.transform.eulerAngles = new Vector3(0.0f, _yaw, 0.0f);
        }
        #endregion
        #region DeadRegion
        if (Playerinfo.GetDesire() == 0)
        {
            Dead = true;
        }
        if(Dead == true)
        {
            //dead
            if(_IntTimeLeft == 5 || _IntTimeLeft == 25 || _IntTimeLeft == 40 || _IntTimeLeft == 90 || _IntTimeLeft == 99)
            {
                Random random;
                _TimeLeftSpeed = Random.Range(0, 5);
            }
            _TimeLeft += Time.deltaTime * _TimeLeftSpeed;
            _IntTimeLeft = (int)_TimeLeft;
            DeadContainer.SetActive(true);
            TextBlueScreen.text = _IntTimeLeft + "%";
            if(_IntTimeLeft == 100)
            {
                DeadContainer.SetActive(false);
                EQController.ItemsGold.Clear();
                EQController.UpdateGoldList();
                _IntTimeLeft = 0;
                Playerinfo.EditDesire(100);
                Dead = false;
            }
            //if()
        }
        else if(Dead == false)
        {
            //dead == false
            DeadContainer.SetActive(false);
        }
        #endregion

        ViewFinderText.transform.TransformPoint(Hand.hit.point);
        if (this.gameObject.transform.position.y < 0)
        {
            PlayerTeleport(this.gameObject.transform.position.x, Terrain.terrainData.heightmapHeight + 5, this.gameObject.transform.position.z);
        }
    }
    public void PlayerTeleport(float X, float Y, float Z)
    {
        this.gameObject.transform.position = new Vector3(X, Y, Z);
        Debug.Log("Teleport Player to " + X + " " + Y + " " + Z);
    }
}
