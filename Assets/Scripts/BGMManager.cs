using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private bool temp;
    private string tempName;
    [SerializeField]
    public AudioClip menuBGM, level1BGM, level2BGM, level3BGM;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("BGM").Length > 1)
        {
            for (int i = 1; i < GameObject.FindGameObjectsWithTag("BGM").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("BGM")[i]);
            }
            //GameObject.FindGameObjectsWithTag("BGM")[1].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ToJ Level1" && tempName != "ToJ Level1")
        {
            tempName = "ToJ Level1";
            gameObject.GetComponent<AudioSource>().clip = level1BGM;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (SceneManager.GetActiveScene().name == "ToJ Level2" && tempName != "ToJ Level2")
        {
            tempName = "ToJ Level2";
            gameObject.GetComponent<AudioSource>().clip = level2BGM;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (SceneManager.GetActiveScene().name == "ToJ Level3" && tempName != "ToJ Level3")
        {
            tempName = "ToJ Level3";
            gameObject.GetComponent<AudioSource>().clip = level3BGM;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (SceneManager.GetActiveScene().name == "ToJ Main Menu" && tempName != "ToJ Main Menu")
        {
            tempName = "ToJ Main Menu";
            gameObject.GetComponent<AudioSource>().clip = menuBGM;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
