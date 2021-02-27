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
    private bool retreating;

    private Vector3 startPursuitLocation;
    private Vector3 endPursuitLocation;
    void Start()
    {
        startPursuitLocation = transform.position;

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
        int layerMask = 1 << 6;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), losDistance, layerMask) && !retreating)
        {
            //Debug.Log("Did Hit");
            inPursuit = true;
            endPursuitLocation = GameObject.FindWithTag("Player").transform.position;
        }
    }

    void Update()
    {
        PlayerDetection();
        if (inPursuit && team != GameObject.FindWithTag("GameManager").GetComponent<GameManager>().currentColour)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPursuitLocation, movementSpeed);
            if (transform.position == endPursuitLocation)
            {
                inPursuit = false;
                retreating = true;
            }
        }
        else if (retreating)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPursuitLocation, movementSpeed);
            if (transform.position.x == startPursuitLocation.x && transform.position.y == startPursuitLocation.y)
            {
                retreating = false;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }    
    }
}
