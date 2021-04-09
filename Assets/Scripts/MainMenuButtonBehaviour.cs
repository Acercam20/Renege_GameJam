using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonBehaviour : MonoBehaviour
{
    public GameObject sfxGameObject;
    private AudioSource sfxSource;
    void Start()
    {
        sfxGameObject = GameObject.FindWithTag("SFX");
        sfxSource = sfxGameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGameButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        SceneManager.LoadScene("ToJ Level1");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnOptionsButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        SceneManager.LoadScene("Options");
    }

    public void OnHTPButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        SceneManager.LoadScene("HowToPlay");
    }

    public void OnExitGameButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        Application.Quit();
    }

    public void OnCreditsButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        SceneManager.LoadScene("Credits");
    }

    public void OnBackButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        SceneManager.LoadScene("ToJ Main Menu");
    }

    public void OnResumeButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().PauseGame(false);
    }

    public void OnPauseButtonPressed()
    {
        sfxSource.PlayOneShot(sfxGameObject.GetComponent<SFXManager>().buttonPress);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().PauseGame(true);
    }
}
