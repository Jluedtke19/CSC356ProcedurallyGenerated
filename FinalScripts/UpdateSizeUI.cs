using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Has the size settings and displays them on the text box. We have the actual values for these so we check them and then dispaly their difficulties
 */


public class UpdateSizeUI : MonoBehaviour {

    string[] Sizes;

    Text text;

    private int RealSize;
    // Use this for initialization

    private void Start()
    {
        Sizes = new string[3];
        Sizes[0] = "Small";
        Sizes[1] = "Medium";
        Sizes[2] = "Large";
    }

    void Awake () {

        text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {


        RealSize = PlayerPrefs.GetInt("MazeSize");

        if(RealSize == 15)
        {
            text.text = Sizes[2];
        }
        if(RealSize == 10)
        {
            text.text = Sizes[1];
        }
        if (RealSize == 5)
        {
            text.text = Sizes[0];
        }
	}
}
