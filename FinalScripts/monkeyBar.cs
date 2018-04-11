using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=Q8GBfN0M0iw for a tutorial 
public class monkeyBar : MonoBehaviour {
    public GameObject handSign; 
   public Vector3 gripPoint;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Make sure controller is grabbing it and if it is set swing equal to true, set the movement manager Speedtime(The running motion, so you can swing) to 0
        if (other.gameObject.GetComponent<ControllerHand>() != null) {
            other.gameObject.GetComponent<ControllerHand>().swing(true);
            
            //Stop Running
            other.gameObject.GetComponentInParent<movementManager>().speedTime = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Check controller, not swinging anymore and enable gravity
        if (other.gameObject.GetComponent<ControllerHand>() != null)
        {
            other.gameObject.GetComponent<ControllerHand>().swing(false);
            other.gameObject.GetComponentInParent<Rigidbody>().useGravity = true;


            //Debug.Log("trigger Exit monlkey");
        }
    }


    public void setHandSign(bool iss) {

        if (handSign!=null) {
            //Had hand signs on them but we didn't like it
            //andSign.SetActive(iss);
        }
    }
}
