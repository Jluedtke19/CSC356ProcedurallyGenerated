using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the movement and behavior of the Crusher obstacle
 **/


public class Crusher : MonoBehaviour {

    private float speed = 15.0f;
    //Up or down
    private int direction = -1;
    private float yMax = 10.0f;
    private float yMin = 1.0f;


    private bool isCrushing = true;
    private float crushTimer = 0.0f;

	// Update is called once per frame
	void Update () {

        if (isCrushing)
        {
            //Value that updates the position of the crusher
            float yNew = transform.localPosition.y + direction * speed * Time.deltaTime;
            //If it goes over max it stops crushing and changes direction
            if (yNew >= yMax)
            {
                //So it doesn't go over the max
                yNew = yMax;
                direction *= -1;
                isCrushing = false;
            }
            //When it comes back up
            else if (yNew <= yMin)
            {
                yNew = yMin;
                direction *= -1;
            }
            //Updates the positon
            transform.localPosition = new Vector3(0, yNew, 0);
        }
        //When it's not crushing there is a count down timer to the next crush
        else
        {
               crushTimer -= Time.deltaTime;   
            if (crushTimer <= 0.0f)
            {
                crushTimer = Random.Range(3.0f, 6.0f);
                isCrushing = true;
            }

        }

    }

    //If you collide with the crusher you die
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the player is colliding with the object
        if (collision.gameObject.GetComponent<adjustCollider>() != null && collision.gameObject.GetComponentInChildren<RagdollController>())
        {
            //Make them dead
            collision.gameObject.GetComponentInChildren<RagdollController>().isDead = true;
            //So it doesn't collide with the player controllers
            Physics.IgnoreLayerCollision(9, 10);
            //Goes back up
            direction = 1;
        }
    }
}
