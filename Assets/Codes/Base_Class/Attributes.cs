using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public bool underAttack;
    public float timeAttacked;

    //velocity
    public float onGroundVelocity_H;
    public float velocity_H;


    //Components
    public AnimCon mAnimCon;
    public Rigidbody2D mRigidBody;

    protected void base_Initialization(){
        mAnimCon = new AnimCon(GetComponent<Animator>());
        mRigidBody = GetComponent<Rigidbody2D>();
    }
  
}
