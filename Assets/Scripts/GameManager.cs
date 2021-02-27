using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum WorldColour { White, Red, Green, Blue};

    public WorldColour currentColour;
    public GameObject pauseCanvas;
    private bool isPaused = false;
    public bool enableDayNightCycle = true;
    public bool isDay;
    public float dayDuration;
    public float nightDuration;
    public GameObject HUDCanvas;
    public GameObject SwitchCircle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseGame(false);
        DontDestroyOnLoad(pauseCanvas);
        DontDestroyOnLoad(this);
        SwitchCircle.SetActive(false);

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

    public void ChangeColour(WorldColour newColour)
    {
        int numberOfLights = GameObject.FindGameObjectsWithTag("ColourLight").Length;
        int numberOfEnemies = GameObject.FindGameObjectsWithTag("ColourEnemy").Length;
        if (currentColour != newColour && newColour == WorldColour.White)
        {
            currentColour = WorldColour.White;
            GameObject.FindWithTag("Player").GetComponent<MeshRenderer>().material.color = Color.white;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.white;
            }
        }
        else if (currentColour != newColour && newColour == WorldColour.Red)
        {
            currentColour = WorldColour.Red;
            GameObject.FindWithTag("Player").GetComponent<MeshRenderer>().material.color = Color.red;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.red;
            }
        }
        else if (currentColour != newColour && newColour == WorldColour.Green)
        {
            currentColour = WorldColour.Green;
            GameObject.FindWithTag("Player").GetComponent<MeshRenderer>().material.color = Color.green;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.green;
            }
        }
        else if (currentColour != newColour && newColour == WorldColour.Blue)
        {
            currentColour = WorldColour.Blue;
            GameObject.FindWithTag("Player").GetComponent<MeshRenderer>().material.color = Color.blue;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.blue;
            }
        }
        else
        {

        }
    }

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

    public void ToggleSwitchCircle(bool switchCircleToggle)
    {
        if (switchCircleToggle)
        {
            SwitchCircle.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            SwitchCircle.SetActive(true);
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
