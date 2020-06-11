using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    //Mode
    public bool underAttack;
    public float timeAttacked;
    public bool isOnGround;

    //velocity
    public float onGroundVelocity_H;
    public float velocity_H;


    //Components
    public AnimCon mAnimCon;
    public Detector mDetector;
    public Rigidbody2D mRigidBody;
    public Collider2D mCollider;

    protected void base_Initialization(){
        mAnimCon = new AnimCon(GetComponent<Animator>());
        mDetector = new Detector();
        mRigidBody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
    }
  
}
