using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
    public bool enableDayNightCycle = true;
    public bool isDay;
    public float dayDuration;
    public float nightDuration;

    void Start()
    {
        PauseGame(false);
        DontDestroyOnLoad(pauseCanvas);
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }

    public void PauseGame(bool _pause)
    {
        if (_pause)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseCanvas.SetActive(isPaused);
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseCanvas.SetActive(isPaused);
        }
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    /*******************************
     * Day / Night Cycle Functions *
     * *****************************/

    public void SetToDay()
    {

    }

    public void SetToNight()
    {

    }

    public void DayTransition()
    {

    }

    public void NightTransition()
    {

    }
}
