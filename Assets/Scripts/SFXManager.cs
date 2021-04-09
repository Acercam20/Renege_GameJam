using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip buttonPress, warpWalls, checkpoints, pause, unpause, takeDamage, landing, timePower, holoCube, timeResume;
    void Start()
    {
        DontDestroyOnLoad(this);

        if (GameObject.FindGameObjectsWithTag("SFX").Length > 1)
        {
            for (int i = 1; i < GameObject.FindGameObjectsWithTag("SFX").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("SFX")[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
