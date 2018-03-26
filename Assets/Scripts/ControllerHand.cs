using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHand : MonoBehaviour
{

    private SteamVR_TrackedObject trackObject;
    private SteamVR_Controller.Device device;
    Rigidbody rg;
    //Rigidbody rg3po;
    SteamVR_ControllerManager cm;
    Vector3 controllerPos;
    Vector3 controllerPosFinal;
   

    movementManager mM;

    //public float movementThreshold=1;
    // Use this for initialization
    void Awake()
    {
        trackObject = GetComponent<SteamVR_TrackedObject>();
        
        cm = FindObjectOfType<SteamVR_ControllerManager>().GetComponent<SteamVR_ControllerManager>();
        rg = GetComponentInParent<Rigidbody>();
        mM = GetComponentInParent<movementManager>();
       // rg3po = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackObject.index);
        
        /**
         if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
             // Debug.Log("Running");
             //controllerPos = transform.position;
            
             rg.position += new Vector3(poop.x,poop.y,poop.z)*Time.deltaTime ;
         }
     **/
        /**
           if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
           {
               rg.position += new Vector3(poop.x, 0, poop.z) * Time.deltaTime * 2.5f;
           }
       **/
        /**
         if (device.velocity.magnitude>2)
         {
             mM.speedTime += Time.deltaTime;
             rg.position += new Vector3(poop.x, 0, poop.z) * Time.deltaTime * 2.5f;
         }
     **/
        if (device.velocity.magnitude > 2)
        {
            mM.speedTime += Time.deltaTime*2f;
            
        }
        


        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            
            //Debug.Log("Done running");

            //controllerPosFinal = transform.position;
            //Debug.Log(controllerPos + " then " + controllerPosFinal);
             rg.velocity = new Vector3(0, 0, 0);
            rg.angularVelocity = new Vector3(0, 0, 0);
        }
        //InertiaStuff();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<VisualCell>() != null)
        {
            rg.velocity = new Vector3(0, 0, 0);
            rg.angularVelocity = new Vector3(0, 0, 0);
        }
    }


    void InertiaStuff() {

        Debug.Log(device.velocity);

    }

}
