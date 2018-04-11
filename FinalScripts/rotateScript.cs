using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script rotates the cross platform, and the spinning obstacle
 * 
 * 
 * 
 */
public class rotateScript : MonoBehaviour {

    public bool isPlatform;

    int randChange;
	// Use this for initialization
	void Start () {

        transform.rotation = Quaternion.Euler(0,Random.Range(0,180),0); //random start roatation

        if (Random.Range(0, 1f) <= .5f) //changes direction of spin
        {
            randChange = -1;

        }
        else {
            randChange = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, .5f * randChange, 0);
	}

    //This is the lava floor, if the player collides with it they die and the Phsycis
    //IgnoreLayerCollision makes it so the contorlers don't colide with anything 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<adjustCollider>() != null && collision.gameObject.GetComponentInChildren<RagdollController>() && !isPlatform)
        {
            collision.gameObject.GetComponentInChildren<RagdollController>().isDead = true;
            Physics.IgnoreLayerCollision(9, 10);
        }
    }


}
