using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTransform : MonoBehaviour {

    public Transform change;
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(change.transform.position.x, transform.position.y, change.transform.position.z);
       
        transform.rotation = Quaternion.Euler(transform.rotation.x, change.transform.rotation.y, transform.rotation.z);



        //Debug.Log(transform.position.y + "XBOT");
    }
}
