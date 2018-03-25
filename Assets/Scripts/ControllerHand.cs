using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHand : MonoBehaviour {

    private SteamVR_TrackedObject trackObject;
    private SteamVR_Controller.Device device;
    Rigidbody rg;
    SteamVR_ControllerManager cm;
    Vector3 controllerPos;
    Vector3 controllerPosFinal;
    GameObject headset;
	// Use this for initialization
	void Awake () {
        trackObject = GetComponent<SteamVR_TrackedObject>();
        headset = GameObject.FindGameObjectWithTag("MainCamera");
        cm = FindObjectOfType<SteamVR_ControllerManager>().GetComponent<SteamVR_ControllerManager>();
        rg = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackObject.index);
        Vector3 poop = headset.transform.forward.normalized;
       
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
            // Debug.Log("Running");
            //controllerPos = transform.position;
           
            rg.velocity = new Vector3(poop.x*50,poop.y*50,poop.z*50) ;
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log("Done running");

            //controllerPosFinal = transform.position;
            //Debug.Log(controllerPos + " then " + controllerPosFinal);
            rg.velocity = new Vector3(0, 0, 0);
        }

        
    }
}
