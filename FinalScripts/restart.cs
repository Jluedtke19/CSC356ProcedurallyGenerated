using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 *  The Restart script is on the restart option on the death UI. Gets the cell the person started in, deletes the player,
 *  then instantiates the player in the start cell, and then enables the controllers
 * 
 */

public class restart : MonoBehaviour {

     public GameObject halo;
    //is called when the player restarts the  current maze after dying
    public void Restart() {
        SpawnPlayer[] spa = FindObjectsOfType<SpawnPlayer>();
        foreach (SpawnPlayer a in spa) {
            if (a.GetStartCell()) {
                Destroy(FindObjectOfType<highPlayer>().gameObject);
                FindObjectOfType<SpawnManager>().InstantiatePlayer();
                ControllerHand[] hands = FindObjectsOfType<ControllerHand>();
                foreach (ControllerHand c in hands) {
                    c.liveCall();
                }
            }

        }

    }
    //Highlights the restart option
    public void haloActive(bool b) {

        halo.SetActive(b);


    }
}
