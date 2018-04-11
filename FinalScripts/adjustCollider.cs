using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Updates the box collider on the player model so that it collides with the ground and doesn't fall through
 **/


public class adjustCollider : MonoBehaviour {

    public GameObject head;
    BoxCollider bX;

	// Use this for initialization
	void Awake () {
        bX = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        bX.center = new Vector3(head.transform.localPosition.x, bX.center.y, head.transform.localPosition.z);
	}
}
