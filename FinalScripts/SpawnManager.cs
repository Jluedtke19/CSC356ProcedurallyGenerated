using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * This script instantiates the player in the start cell and makes the end sell the end game object
 */

public class SpawnManager : MonoBehaviour {
    GameObject start;
    GameObject end;
    SpawnPlayer[] sp;
    public GameObject player;
	// Use this for initialization
	public void FindSpawners () {
        sp = FindObjectsOfType<SpawnPlayer>();
	}
	
	// Update is called once per frame
	public void InstantiatePlayer () {

        for (int i = 0; i < 4; i++) {
            if (sp[i].GetComponent<SpawnPlayer>().GetStartCell()) {
              start =  sp[i].gameObject;

            }
            if (sp[i].GetComponent<SpawnPlayer>().GetEndCell())
            {
                end = sp[i].gameObject;

            }



        }
        //Colider that triggers the end affects
        end.GetComponent<SphereCollider>().enabled = true;
       
        //Puts the player in the start location
GameObject poo = Instantiate( player, start.gameObject.transform.position, Quaternion.identity);
        //So they don't move when they spawn
        poo.GetComponentInChildren<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //Gives the player collision and so they don't pinch
        Physics.IgnoreLayerCollision(9, 10, false);
    }
}
