using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Sets the position of the trail renderer
 */


public class trialScript : MonoBehaviour {

    public GameObject rig;
    public GameObject head;

    TrailRenderer tR;

	// Use this for initialization
	void Awake () {
        tR = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(head.transform.position.x, rig.transform.position.y + .1f, head.transform.position.z);



	}
}
