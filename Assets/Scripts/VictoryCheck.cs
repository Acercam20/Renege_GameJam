using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    public bool Victory;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
