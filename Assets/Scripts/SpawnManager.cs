using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    SpawnPlayer[] sp;
    public GameObject player;
	// Use this for initialization
	public void FindSpawners () {
        sp = FindObjectsOfType<SpawnPlayer>();
	}
	
	// Update is called once per frame
	public void InstantiatePlayer () {

        Debug.Log(sp.Length);


GameObject poo = Instantiate(player, sp[(Random.Range(0, sp.Length - 1))].gameObject.transform.position, Quaternion.identity);

        poo.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

    }
}
