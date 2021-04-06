using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotater : MonoBehaviour
{
    // Start is called before the first frame update
    public bool rotateX, rotateY, rotateZ;
    public float rotateSpeedX, rotateSpeedY, rotateSpeedZ;

    public float moveSpeed;
    public float moveRangeX, moveRangeY, moveRangeZ;

    public bool isKillBox;
    public bool activeOnTouch;
    public bool dissapearOnTouch;
    public float fadeDuration;

    private Vector3 startingPos;
    private bool isActive;
    //private bool isFading;
    private float distance;
    private bool goalReached;
    void Start()
    {
        startingPos = transform.position;
        if (!activeOnTouch)
            isActive = true;
        else
            isActive = false;
    }

    void Update()
    {

        if (isActive)
        {
            Spinning();
            Moving();
        }
    }

    void Spinning()
    {
        if (rotateX)
            transform.Rotate(Vector3.right * (rotateSpeedX * Time.deltaTime * GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime));
        if (rotateY)
            transform.Rotate(Vector3.up * (rotateSpeedY * Time.deltaTime * GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime));
        if (rotateZ)
            transform.Rotate(Vector3.forward * (rotateSpeedZ * Time.deltaTime * GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime));
    }

    void Moving()
    {
        distance = Vector3.Distance(transform.position, new Vector3(startingPos.x + moveRangeX, startingPos.y + moveRangeY, startingPos.z + moveRangeZ));

        if (activeOnTouch)
        {
            if (goalReached)
                transform.position = Vector3.MoveTowards(transform.position, startingPos, moveSpeed / 100 * GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPos.x + moveRangeX, startingPos.y + moveRangeY, startingPos.z + moveRangeZ), moveSpeed / 100 * GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime);

            if (distance < 1)
            {
                goalReached = true;
            }
            if (Vector3.Distance(transform.position, startingPos) < 0.001f && goalReached)
            {
                goalReached = false;
                isActive = false;
            }
        }
        else
        {
            if (goalReached)
                transform.position = Vector3.MoveTowards(transform.position, startingPos, moveSpeed / 100 * GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPos.x + moveRangeX, startingPos.y + moveRangeY, startingPos.z + moveRangeZ), moveSpeed / 100 * GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime);

            if (distance < 1)
            {
                goalReached = true;
            }
            if (Vector3.Distance(transform.position, startingPos) < 1)
            {
                goalReached = false;
            }
        } 
    }

    void Fade()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isKillBox && GameObject.FindWithTag("GameManager").GetComponent<GameManager>().worldTime >= 1)
            {
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
            }

            if (activeOnTouch)
                isActive = true;
            if (dissapearOnTouch)
            {
                //isFading = true;
                Fade();
            }
            if (!rotateX && !rotateY && !rotateZ)
                collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!rotateX && !rotateY && !rotateZ)
            collision.gameObject.transform.parent = null;
    }
}
