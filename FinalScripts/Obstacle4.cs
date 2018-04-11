using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotating cross obstacle

public class Obstacle4 : MonoBehaviour {

    //This is the lava floor, if the player collides with it they die and the Phsycis
    //IgnoreLayerCollision makes it so the contorlers don't colide with anything 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInChildren<RagdollController>() != null)
        {
            collision.gameObject.GetComponentInChildren<RagdollController>().isDead = true;
            Physics.IgnoreLayerCollision(9, 10);
        }
    }
}
