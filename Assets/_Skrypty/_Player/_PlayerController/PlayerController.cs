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

    public GameObject camera;

    
    private void Update()
    {
        Vector3 _Move;
        _Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.gameObject.transform.Translate(_Move * MoveSpeed * Time.deltaTime);

        #region Camera Rotation
        _yaw += _CamSpeedH * Input.GetAxis("Mouse X");
        _pitch -= _CamSpeedV * Input.GetAxis("Mouse Y");

        camera.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
        this.gameObject.transform.eulerAngles = new Vector3(0.0f, _yaw, 0.0f);
        #endregion

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camera.transform.position, camera.transform.eulerAngles, out hit, 100))
        {
            Debug.Log(hit.collider.gameObject.name);
            int XPoint = int.Parse(hit.point.x.ToString());
            int ZPoint = int.Parse(hit.point.z.ToString());
            GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().EditTerrainHeight(XPoint, ZPoint, -1);
            Debug.DrawLine(camera.transform.position, hit.point, Color.green);

        }
    }
}
