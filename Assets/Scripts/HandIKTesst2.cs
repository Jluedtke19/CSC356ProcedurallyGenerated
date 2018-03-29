using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIKTesst2 : MonoBehaviour {

    public  Transform head1;

    public Transform shoulderR;
    public Transform shoulderL;

    public Transform hips;
    

    Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    private void OnAnimatorIK(int layerIndex)
    {
        /**
        Transform head = anim.GetBoneTransform(HumanBodyBones.Neck);
        head.rotation = head1.rotation;
        head.position = head1.position; 
    **/
    }

    private void LateUpdate()
    {
        /**
        Transform head = anim.GetBoneTransform(HumanBodyBones.Head);
        head.rotation = Quaternion.Euler(head.rotation.x, head1.rotation.y, head.rotation.z);
        head.position = head1.position;
        **/
        Transform hipsAv = anim.GetBoneTransform(HumanBodyBones.Hips);
        hipsAv.rotation = hips.rotation;
        hipsAv.position = hips.position;

        /**
        Transform shoulderRight = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
        shoulderRight.rotation = shoulderR.rotation;
        shoulderRight.position = shoulderR.position;

        Transform shoulderLeft = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
        shoulderLeft.rotation = shoulderL.rotation;
        shoulderLeft.position = shoulderL.position;
    **/


    }



}
