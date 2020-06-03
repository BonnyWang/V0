using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCon
{
    Animator mAnimator;

    float backOff_H = 5f;
    float backOff_V = 2f;
    public AnimCon(Animator animator){
        mAnimator = animator;
    }

    public void changeAnim(string name,bool state){
        mAnimator.SetBool(name,state);
    }

    //Effects
    public void backBounce(GameObject gameObject, GameObject other){
        Vector2 backOff = new Vector2(Mathf.Sign(gameObject.transform.position.x-other.transform.position.x)*backOff_H,backOff_V);
        gameObject.GetComponent<Rigidbody2D>().AddForce( backOff,ForceMode2D.Impulse);
    }
}
