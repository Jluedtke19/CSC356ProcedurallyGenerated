using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIKTesst : MonoBehaviour {

    public  Transform thisHand;

    

    Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, thisHand.transform.position);
        anim.SetIKRotation(AvatarIKGoal.RightHand, thisHand.transform.rotation);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    }

   
}
