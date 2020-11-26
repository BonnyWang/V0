using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCon
{
    Animator mAnimator;

    public float backOff_H = 3f;
    public float backOff_V = 2f;
    public AnimCon(Animator animator){
        mAnimator = animator;
    }

    public void changeAnim(string name,bool state){
        mAnimator.SetBool(name,state);
    }

    public bool getVariable(string name){
        return mAnimator.GetBool(name);
    }

    //Effects
    public void backBounce(GameObject gameObject, GameObject other, Vector2 backOff){
        Debug.Log("backoff"+backOff.x);
        gameObject.GetComponent<Rigidbody2D>().AddForce(backOff,ForceMode2D.Impulse);
    }

    public void flipSprite(Transform mtransform)
    {
        mtransform.localScale = new Vector2(Mathf.Sign(mtransform.gameObject.GetComponent<Rigidbody2D>().velocity.x), 1f);
    }

}
