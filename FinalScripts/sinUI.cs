using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class sinUI : MonoBehaviour {

    float amplitude;
    float speed;
    float start;
	// Use this for initialization
	void Start () {
        amplitude = Random.Range(-1,1);
        speed = Random.Range(.05f, 1);
        start = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, start + amplitude * Mathf.Sin(speed * Time.time), transform.position.z) ;
    }
}
