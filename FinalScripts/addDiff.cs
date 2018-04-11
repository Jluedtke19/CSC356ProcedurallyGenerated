using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Used on the main menu and is attached to the up arrow that the player collides with. Once collided with it adds
 * public int(which is set to one for this) that determines the percentage that obstacles spawn at.
 **/


public class addDiff : MonoBehaviour {
    AudioSource AS;

    public int sizetoadd;
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ControllerHand>() != null)
        {
            
            FindObjectOfType<StartScript>().SetDifficulty(sizetoadd);
            AS.Play();

        }
    }
}
