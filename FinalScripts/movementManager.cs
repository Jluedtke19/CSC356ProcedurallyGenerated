using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class movementManager : MonoBehaviour {

   public GameObject headset; //Head Mounted Display
    Rigidbody rg; //RigidBody Component
    public float speedTime; //The duration of time that the player is moving currently

    public bool isSwinging = false; //is the player interacting with an obstacle
    public bool isDead = false; //is the player sleeping with the fishes
    //NetworkIdentity NI;


    private void Awake()
    {
        rg = GetComponentInParent<Rigidbody>();
       // NI = GetComponentInParent<NetworkIdentity>();

        /**
        if (!NI.isLocalPlayer)
        {
           // headset.SetActive(false);
        }
    **/


    }

    private void Start()
    {
        rg.velocity = new Vector3(0, 0, 0); //reset velocity incase of colliders spawning over eachother and pinching
        rg.angularVelocity = new Vector3(0, 0, 0);

    }
    // Update is called once per frame
    void Update () {
        /**
        if (!NI.isLocalPlayer) {
            return;
        }
    **/
        Vector3 poop = headset.transform.forward.normalized; //the direction the player is looking
        speedTime -= Time.deltaTime;
        if (speedTime<0) {
            speedTime = 0;
        }
        //So you don't go over the mzx
        if (speedTime > 1)
        {
            speedTime = 1;
        }

        //Updates the model/rigidody based on the speedtime, DeltaTime changes it over time and the 2.5 is to scale the movement better
        if (speedTime > 0 && !isSwinging && !isDead)
        {

            rg.position += new Vector3(poop.x, 0, poop.z) * Time.deltaTime * speedTime*2.5f; //add to the players position while running
        }
    }
}
