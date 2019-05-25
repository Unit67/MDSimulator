using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkInfo : MonoBehaviour
{
    private bool TrunkOpen;

    public void SetTrunkOpen(bool Open)
    {
        TrunkOpen = Open;
    }
    public bool GetTrunkOpen()
    {
        return TrunkOpen;
    }
    
}
