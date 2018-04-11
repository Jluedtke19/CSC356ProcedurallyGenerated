using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerHand : MonoBehaviour
{
    AudioSource AS;
    //public AudioClip grabSound;

    private SteamVR_TrackedObject trackObject; // real world transform of the controller
    private SteamVR_Controller.Device device; // the input from the controller
    Rigidbody rg; //rigidbody compnent
    
    Vector3 prevPos; //controllers previous position, used to move the player
    bool isSwinging; //is the controller interacting with an obstacle

    public GameObject hand; //hands local position

    public bool isDead = false; //is the player dead

    public GameObject handModel; //render of the controller
    movementManager mM; //manages the player movement

    public GameObject deathUI;//Menu that shows on your hand when you die, can restart or go to the main menu

    public Material selected;//For the death UI to see what option is selected
    public Material notSelected;//For the death UI to see wha option isn't selected

    public bool won = false;


    //Stores the position of the hand so we can update the rigid body(the model)
    private void Start()
    {
        prevPos = hand.transform.localPosition;

    }
    

    //Gets the objects; the controllers, the model(rigidbody), the movment manager to , and the audio source for grab sounds
    void Awake()
    {
        trackObject = GetComponent<SteamVR_TrackedObject>();
        rg = GetComponentInParent<Rigidbody>();
        mM = GetComponentInParent<movementManager>();
        AS = GetComponent<AudioSource>();
    }
    
   
    void FixedUpdate()
    {
        //Gets the controller
        device = SteamVR_Controller.Input((int)trackObject.index);

            
            //This is the regular running, if we aren't swinging and aren't dead we run
            if (device.velocity.magnitude > 2 && !isSwinging && !isDead)
        {
                mM.speedTime += Time.deltaTime*2f;
            
        }
            //If we are swinging on the monkey bar and the grip is pressed and we aren't dead
            if (isSwinging && device.GetPress(SteamVR_Controller.ButtonMask.Grip) && !isDead) {
                AS.Play();
                rg.transform.position+= (prevPos - hand.transform.localPosition);
                //Gravity is off so we can move around on the jungle gym
                rg.useGravity = false;
                //So we don't collide with the other jungle bars
                rg.isKinematic = true;
        }
                //If we are swinging but let go and aren't dead we swing off
            if (isSwinging && device.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && !isDead)
        {
                //Want gravity and collisions when we swing off
                rg.useGravity = true ;
                rg.isKinematic = false;
            

                rg.velocity = (prevPos - hand.transform.localPosition) / Time.deltaTime;
            //woosh
        }
      
        //Update the hand position so we can move when we swing again
        prevPos = hand.transform.localPosition;

        //When we die we display a menu on the hand to restart the game or go to the main menu
        //Detects where the finger is on the trackpad and highlight the option it corresponds to and if pressed does said option
        if (isDead && (deathUI != null) &&!won) {
            float rollX = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
            if (rollX < -.2)
            {
                GetComponentInChildren<restart>().haloActive(true);
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    GetComponentInChildren<restart>().Restart();
                }

            }
            else {
                GetComponentInChildren<restart>().haloActive(false);
            }




            if (rollX > .2)
            {
                GetComponentInChildren<mainMenu>().haloActive(true);
               
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    GetComponentInChildren<mainMenu>().MainMenu();
                }
            }
            else {
                if (GetComponentInChildren<mainMenu>()!=null) {
                    GetComponentInChildren<mainMenu>().haloActive(false);
                }
                
            }
            

        }




    }


    //Solves the problem of being sent back when colliding with a corner without changing the drag
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<VisualCell>() != null)
        {
            rg.velocity = new Vector3(0, 0, 0);
            rg.angularVelocity = new Vector3(0, 0, 0);
        }
        
    }

    //Sets the swinging boolean
    public void swing(bool isSwinger) {
        isSwinging = isSwinger;
        

}

    //Starts up the  deathUI and sets the isDead variable to true
    public void deadCall() {
        handModel.GetComponent<SteamVR_RenderModel>().enabled = true;
        isDead = true;
        if (deathUI!=null && !won) {
            deathUI.SetActive(true);
            
        }
    }

    //Used when the player restarts the maze so they don't have the death UI
    public void liveCall() {
        handModel.GetComponent<SteamVR_RenderModel>().enabled = false;
        isDead = false;
        if (deathUI != null)
        {
            deathUI.SetActive(false);

        }

    }

}
