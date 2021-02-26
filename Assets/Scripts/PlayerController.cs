using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {

    }

    public void Move()
    {

    }

    public void Look()
    {

    }

    public void Pause()
    {
        if (gameManager.IsPaused())
        {
            gameManager.PauseGame(false);
        }
        else
        {
            gameManager.PauseGame(true);
        }
    }
}
