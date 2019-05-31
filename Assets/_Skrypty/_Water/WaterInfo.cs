using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInfo : MonoBehaviour
{
    public enum Water
    {
        CleanWater,
        DirtyWater,
        SweetWater,
        SaltWater
    }
    public Water WaterType;
}
