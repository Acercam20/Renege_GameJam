using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpWall : MonoBehaviour
{
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("SFX").GetComponent<AudioSource>().PlayOneShot(GameObject.FindWithTag("SFX").GetComponent<SFXManager>().warpWalls);
            collision.gameObject.transform.position = destination.position;
        }
    }
}
