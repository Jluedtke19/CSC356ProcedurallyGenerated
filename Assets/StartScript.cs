using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ControllerHand>()!=null) {
            Debug.Log("Colliding with Start");
            SceneManager.LoadScene("MazeGenerationTestOne");

        }
    }
}
