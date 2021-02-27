using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("VictoryCheck").GetComponent<VictoryCheck>().Victory)
            gameObject.GetComponent<Text>().text = "Victory!";
        else
            gameObject.GetComponent<Text>().text = "Defeat";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
