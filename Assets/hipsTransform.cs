using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hipsTransform : MonoBehaviour {

    public Transform head;
    public Transform rig;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(head.transform.position.x, transform.position.y, head.transform.position.z);
        transform.rotation =  Quaternion.Euler(head.transform.rotation.x, head.transform.rotation.y, head.transform.rotation.z);
        //  Debug.Log(transform.position.y + " HIPS");
        //  Debug.Log((head.transform.position.y + rig.transform.position.y) / 2);
        //Debug.Log(transform.localRotation);
	}
}
