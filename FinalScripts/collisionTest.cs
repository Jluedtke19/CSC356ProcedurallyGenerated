using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour {

    SphereCollider sp;
    GameObject headset;

    private void Awake()
    {
        sp = GetComponent<SphereCollider>();
        headset = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        
    }


    private void Update()
    {
        float dist = Vector3.Distance(transform.position, headset.transform.position);
       // Debug.Log(dist);
         sp.center = new Vector3(transform.position.x + headset.transform.localPosition.x, transform.position.y+ headset.transform.localPosition.y, transform.position.z + headset.transform.localPosition.z);
    }
}
