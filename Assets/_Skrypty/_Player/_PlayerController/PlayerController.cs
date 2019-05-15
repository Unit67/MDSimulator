using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5;

    private float _CamSpeedH = 2.0f;
    private float _CamSpeedV = 2.0f;
    private float _yaw = 0.0f;
    private float _pitch = 0.0f;
    private float _Gravity = 20.0f;
    private float _VSpeed;
    public GameObject camera;
    public CharacterController CharacterController;
    
    private void Update()
    {
        Vector3 _Move = transform.forward * Input.GetAxis("Vertical") * MoveSpeed;
        _VSpeed -= _Gravity * Time.deltaTime;
        _Move.y = _VSpeed;

        CharacterController.Move(_Move * Time.deltaTime);
        CharacterController.Move(transform.right * Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime);
        
        #region Camera Rotation
        _yaw += _CamSpeedH * Input.GetAxis("Mouse X");
        _pitch -= _CamSpeedV * Input.GetAxis("Mouse Y");

        camera.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
        CharacterController.transform.eulerAngles = new Vector3(0.0f, _yaw, 0.0f);
        #endregion


    }
}
