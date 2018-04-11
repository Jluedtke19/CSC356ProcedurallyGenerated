using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * Obstacle1 is the monkey bars and the lava floor. This script
 * 
 */

public class obstacle1 : MonoBehaviour {

   

	// Use this for initialization

    //Don't need this update but don't want to delete just in case
	void Update() {
        //Stores information 
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 5, transform.forward, out hit, 10)) {
            if (hit.transform.gameObject.GetComponent<adjustCollider>() != null)
            {

                monkeyBar[] mB = GetComponentsInChildren<monkeyBar>();
                foreach (monkeyBar m in mB)
                {
                    //Don't want the hand sign to appear
                    //m.setHandSign(true);
                }
            }
        }
    }

    //This is the lava floor, if the player collides with it they die and the Phsycis
    //IgnoreLayerCollision makes it so the contorlers don't colide with anything 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInChildren<RagdollController>()!=null) {
            collision.gameObject.GetComponentInChildren<RagdollController>().isDead = true;
            Physics.IgnoreLayerCollision(9, 10);
        }
    }
}
