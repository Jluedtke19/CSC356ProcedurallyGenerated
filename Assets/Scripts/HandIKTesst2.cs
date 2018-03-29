using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIKTesst2 : MonoBehaviour {

    public  Transform head1;

    

    Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    private void OnAnimatorIK(int layerIndex)
    {
        Transform head = anim.GetBoneTransform(HumanBodyBones.Head);
        head.rotation = head1.rotation;
        head.position = head1.position; 
    }

   
}
