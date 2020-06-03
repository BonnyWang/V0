using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    static Animator animator;
    public static AnimCon mAnimCon;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        mAnimCon = new AnimCon(animator);
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Enemy"){
            
            mAnimCon.backBounce(gameObject,other.gameObject);
            Player_Attributes.underAttack = true;
            Player_Attributes.timeAttacked = Time.time;
        }
    }
}
