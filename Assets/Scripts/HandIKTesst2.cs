using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIKTesst2 : MonoBehaviour {

    public  Transform head;

    

    Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    private void OnAnimatorIK(int layerIndex)
    {
        //anim.SetLookAtPosition(head.transform.position);
    }

   
}
