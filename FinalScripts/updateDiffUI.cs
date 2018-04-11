using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Has the difficulty settings and displays them on the text box
 */

public class updateDiffUI : MonoBehaviour
{

    string[] Sizes;

    Text text;

    private int RealSize;
    // Use this for initialization

    private void Start()
    {
        Sizes = new string[4];
        Sizes[0] = "Easy";
        Sizes[1] = "Medium";
        Sizes[2] = "Hard";
        Sizes[3] = "Insane";
    }

    void Awake()
    {

        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {


        RealSize = PlayerPrefs.GetInt("Difficulty");

        text.text = Sizes[RealSize];
    }
}