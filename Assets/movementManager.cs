using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementManager : MonoBehaviour {

    GameObject headset;
    Rigidbody rg;
    public float speedTime;

    private void Awake()
    {
        rg = GetComponentInParent<Rigidbody>();
        headset = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Start()
    {
        rg.velocity = new Vector3(0, 0, 0);
        rg.angularVelocity = new Vector3(0, 0, 0);

    }
    // Update is called once per frame
    void Update () {
        Vector3 poop = headset.transform.forward.normalized;
        speedTime -= Time.deltaTime;
        if (speedTime<0) {
            speedTime = 0;
        }

        if (speedTime > 1)
        {
            speedTime = 1;
        }


        if (speedTime > 0)
        {

            rg.position += new Vector3(poop.x, 0, poop.z) * Time.deltaTime * speedTime*2.5f;
        }
    }
}
