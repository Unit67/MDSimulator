using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGenerator : MonoBehaviour
{
    public GameObject Gold;
    private void Start()
    {
        for(int i =0;i<= 500; i++)
        {
            GameObject GoldObject = GameObject.Instantiate(Gold);
            GoldObject.name = "Gold";
            GoldObject.transform.position = new Vector3(Random.Range(0, 520), -1, Random.Range(0, 520));
        }
    }
}
