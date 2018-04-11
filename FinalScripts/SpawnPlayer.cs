using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * 
 * This script sets the start and end cells and upon colliding with the end cell they get the end effects(Fireworks and then going back to the main menu
 * 
 */


public class SpawnPlayer : MonoBehaviour {


    bool isStartCell = false;
    bool isEndCell = false;
    private float waitTime = 5f;

    public GameObject winPrefab;

    //is the start cell
    public bool GetStartCell() {
        return isStartCell;
	}
    //is the end cell
    public bool GetEndCell()
    {
        return isEndCell;
    }

    // updates spawn type
    public void SetSpawnType(bool sC, bool eC) {
        isEndCell = eC;
        isStartCell = sC;


	}



   
    //On trigger if hand, say the player won and instantiate winning prefab
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Rigidbody>()!=null) {

            
            ControllerHand[] cH = FindObjectsOfType<ControllerHand>();
            foreach (ControllerHand c in cH)
            {
                c.won = true;

            }
            if (other.gameObject.GetComponentInParent<RagdollController>()!=null) {
                other.gameObject.GetComponentInParent<RagdollController>().isDead = true;
            }
            
            winPrefab.SetActive(true);
            StartCoroutine(StartC());
            
        }
    }

    //enumerator that waits a few seconds and then changes the scene so they can see the end effects
    IEnumerator StartC()
    {

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainMenu");

    }



}
