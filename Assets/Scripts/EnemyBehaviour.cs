using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameManager.WorldColour team = GameManager.WorldColour.White;
    public bool passiveBool;
    public float movementSpeed;
    public float losDistance;
    private bool inPursuit;
    void Start()
    {
        if (team == GameManager.WorldColour.White)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else if (team == GameManager.WorldColour.Red)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (team == GameManager.WorldColour.Green)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (team == GameManager.WorldColour.Blue)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    void PlayerDetection()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow, Mathf.Infinity);
            //Debug.Log("Did Hit");
            inPursuit = true;
        }
    }

    void Update()
    {
        PlayerDetection();
        if (inPursuit)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, 0.01f);
        }
    }
}
