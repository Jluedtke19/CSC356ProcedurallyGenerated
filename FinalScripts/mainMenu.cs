using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is put on the Main Menu button on the death UI to bring the player back to the main menu


public class mainMenu : MonoBehaviour {
    public GameObject halo;
    public void MainMenu() {

        SceneManager.LoadScene("MainMenu");

    }

    //halo is to show that it is about to be selected
    public void haloActive(bool b)
    {

        halo.SetActive(b);


    }
}
