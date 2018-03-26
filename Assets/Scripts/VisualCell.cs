using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCell : MonoBehaviour {

    public Transform East;
    public Transform West;
    public Transform North;
    public Transform South;


    public void RandomizeScale() {
        float randomAdd = Random.Range(-.05f, 0.05f);
        East.localScale = new Vector3(East.localScale.x + randomAdd, East.localScale.y+ randomAdd, East.localScale.z+ randomAdd);



        Debug.Log(East.localScale+ "" + West.localScale+ "" + North.localScale+"" + South.localScale);

    }
}
