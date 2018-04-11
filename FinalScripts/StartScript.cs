using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is attached to the start button on the main menu. It sets the maze size and difficulty and loads the MazeGenerator scene 
 */
 



public class StartScript : MonoBehaviour {


    public string sceneName;

    public int size;
    public int difficulty;

    private int MaxMazeSize;
    private int MinMazeSize;
    private int MaxDiff;
    private int MinDiff;

    
    //Starts off the values at the min so there is no errors
    private void Start()
    {
        MaxMazeSize = 15;
        MinMazeSize = 5;
        MaxDiff = 3;
        MinDiff = 0;
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("MazeSize"))
        {
            PlayerPrefs.SetInt("MazeSize", MinMazeSize);
        }
        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            PlayerPrefs.SetInt("Difficulty", MinDiff);
        }
    }


    //Makes sure the size doesn't go over the max setting and updates the PlayerPref
    public void SetSize(int sizea)
    {
        
        if (PlayerPrefs.GetInt("MazeSize") + sizea > MaxMazeSize || PlayerPrefs.GetInt("MazeSize") + sizea < MinMazeSize)
        {
            //Do nothing
        }
        else
        {
            PlayerPrefs.SetInt("MazeSize", PlayerPrefs.GetInt("MazeSize") + sizea);
        }
    }


    //Starts the Maze generator
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ControllerHand>()!=null) {
            //Debug.Log("Colliding with Start");
            SceneManager.LoadScene(sceneName);

        }
    }

    //Makes sure the Difficulty isn't over or under max and min and updates the PlayerPref
    public void SetDifficulty(int a) {
        if (PlayerPrefs.GetInt("Difficulty") + a > MaxDiff || PlayerPrefs.GetInt("Difficulty") + a < MinDiff)
        {
            //Do nothing
        }
        else
        {
            PlayerPrefs.SetInt("Difficulty", PlayerPrefs.GetInt("Difficulty") + a);
        }

    }


}
