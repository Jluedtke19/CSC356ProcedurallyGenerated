using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script give the model colliders so they can move around and makes the model "die"
 */

public class RagdollController : MonoBehaviour {
    AudioSource AS;//death sound
    public bool isDead;//To see if the play should go ragdoll
    public GameObject trail;
    Collider[] colliders;

    bool didcall = false;
	// Use this for initialization
	void Awake () {
        //All the ragdoll colliders
        colliders = GetComponentsInChildren<Collider>();
        AS = GetComponent<AudioSource>();
	}

    private void Start()
    {
        if (colliders.Length>0) {
            foreach (Collider c in colliders) {
                //Enables the colliders on the model
                c.isTrigger = true;
                c.GetComponent<Rigidbody>().useGravity = false;
                c.GetComponent<Rigidbody>().isKinematic = true;
            }

        }
    }

    // Update is called once per frame
    void Update () {
        //If we are daed and we didn't call it already, go ragdoll
        if (isDead && !didcall) {
            goRagdoll();
            didcall = true;
        }
	}

    //Makes the model fall to the floor, disables the Final Ik from the model so you can't control it
    //and disables locomotion and plays a death sound
    public void goRagdoll() {

        foreach (Collider c in colliders)
        {
            c.isTrigger = false;
            c.GetComponent<Rigidbody>().useGravity = true;
            c.GetComponent<Rigidbody>().isKinematic = false;
        }

        GetComponent<VRIK>().enabled = false;
        ControllerHand[] cH = FindObjectsOfType<ControllerHand>();
        foreach (ControllerHand c in cH) {
            c.deadCall();

        }

        FindObjectOfType<movementManager>().isDead = true;
        transform.parent = null;
        //trail.GetComponent<TrailRenderer>().enabled = false;\
        AS.Play();
    }

}
