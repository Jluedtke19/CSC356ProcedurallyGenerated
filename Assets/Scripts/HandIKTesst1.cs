using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIKTesst1 : MonoBehaviour {

    public  Transform thisHand;
    

    Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPosition(AvatarIKGoal.LeftHand, thisHand.transform.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, thisHand.transform.rotation);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        
    }

   
}
