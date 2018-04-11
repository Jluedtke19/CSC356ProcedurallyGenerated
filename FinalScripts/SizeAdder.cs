using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *This script is attached to the up button on the size adder and when collided with it makes a sound and increments the size
 */

public class SizeAdder : MonoBehaviour {

    public int sizetoadd;
    AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ControllerHand>() != null) {
            FindObjectOfType<StartScript>().SetSize(sizetoadd);
            // PlayerPrefs.SetInt("MazeSize", PlayerPrefs.GetInt("MazeSize") + sizetoadd);
            AS.Play();
        }
    }
}
