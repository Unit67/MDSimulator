using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EQController : MonoBehaviour
{
    public GameObject EQContainer;
    bool _ShowEQ;
    public Text[] ItemText;
    public RawImage[] ItemImage;
    public MetalDetector MetalDetector;
    public Hand Hand;
    private GameObject _Camera;
    public List<GameObject> ItemsGold;
    private GameObject _MetalDetectorContainer;
    private GameObject _MetalDetector;
    public GameObject Gold;
    private void Start()
    {
        _Camera = GameObject.Find("Main Camera");
        if (_MetalDetectorContainer == null)
        {
            _MetalDetectorContainer = GameObject.Find("MetalDetector container");
        }
        if (_MetalDetector == null)
        {
            _MetalDetector = GameObject.Find("MetalDetector");
        }
        EQContainer = GameObject.Find("EQ Container");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _ShowEQ = !_ShowEQ;
        }
        switch(_ShowEQ)
        {
            case true:
                {
                    EQContainer.SetActive(_ShowEQ);
                }
                break;
            case false:
                {
                    EQContainer.SetActive(_ShowEQ);
                }
                break;
        }
        if(_ShowEQ == true)
        {
            //for (int i = 0; i <= ItemsGold.Count; i++)
            //{
            if(ItemsGold.Count > 0)
            {
                ItemText[0].text = "Gold " + "(" + ItemsGold.Count + ")";
                Debug.Log("Gold" + "(" + ItemsGold.Count + ")");
            }
                //for (int j = 0; j <= ItemImage.Length; j++)
                //{
                    //ItemImage[j].texture = 
              //  }
            //}
            
        }
        RaycastHit hit;
        Ray ray;
        if(Physics.Raycast(_Camera.transform.position,_Camera.transform.forward, out hit, 10))
        {
            Debug.DrawLine(_Camera.transform.position, hit.point, Color.black);

            /* for (int i = 0; i <= MetalDetector.GoldList.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (hit.collider.name == "Gold")
                    {
                        ItemsGold[i] = hit.collider.gameObject;
                    }
                    else
                    {
                        break;
                    }
                }
            }*/
        }
    }

    public void GoldButton()
    {
        if (ItemsGold.Count > 0)
        {
            Gold = ItemsGold[ItemsGold.Count - 1];
            Hand.NewParent(_MetalDetectorContainer, Gold);
            Gold.transform.localPosition = new Vector3(0, 0, 0);
            Gold.transform.localEulerAngles = new Vector3(0, 90, 0);
            Gold = null;
            ItemsGold.RemoveAt(ItemsGold.Count - 1);
        }
    }
}
