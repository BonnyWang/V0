﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{

    //Variables
    //Movement
    float translation_H;
    float translation_V;
    float velocity_H;
    
    bool space_Jump;
    Vector2 updated_PlayerVelocity;

    //Mode
    bool inAir;
    bool canJump;
    bool canInteract;
    bool moving_Forced_H;
    float direction_H;
    // bool wearMask;
    //int whichMask
    // bool underAttack;
    // float time_Attacked;
    bool onGround;
    // float distance_ToEnemyAttaed;



    //Components
    Rigidbody2D playerRB;
    Transform playerTF;
    BoxCollider2D playerCL;
    Animator playerAN;
    Player_Attributes mAttr;
    
    //Properties to be Adjusted
    [SerializeField] float ground_Velocity_H = 1f;
    [SerializeField] float inAir_Velocity_H = 1.5f;
    [SerializeField] float inAir_Velocity_V = 5f;
    [SerializeField] float recoveryTime = 1.5f;
    // [SerializeField] bool canJump;




    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerTF = GetComponent<Transform>();
        playerCL = GetComponent<BoxCollider2D>();
        playerAN = GetComponent<Animator>();
        mAttr = GetComponent<Player_Attributes>();


        canJump = true;
        canInteract = true;
        // wearMask = false;
        // underAttack = false;
    }

    void Update()
    {
        //Interaction Detect
        translation_H =  Input.GetAxis("Horizontal");
        translation_V = Input.GetAxis("Vertical");
        space_Jump = Input.GetButtonDown("Jump");

        //Mode Detect
        detectState();
        velocity_Control();
        detectCanJump();
        animation_Control();
        detectCanIneract();


        //Interaction Control(can be a function later)
        if(canInteract){
            interactControll();
        }
            

    }

    void interactControll(){
        if(Mathf.Abs(translation_H)>0){
            
            if(Mathf.Sign(playerRB.velocity.x) != Mathf.Sign(playerTF.localScale.x)){
                Player_Animation.mAnimCon.flipSprite(transform);
                // flipSprite();
            }

            move();
            moving_Forced_H = true;
        }else{
            moving_Forced_H = false;
            
        }

        //TODO:Need to change?
        if(translation_V != 0){
            if(Player_Attributes.onRope){
                if(translation_V == 1f){
                    mAttr.player_Interaction.moveUpRope();
                }else if(translation_V == -1f){
                    mAttr.player_Interaction.moveDownRope();
                }
            }
            
        }
        
        if(space_Jump){
            if(canJump){
                Jump();
            }else if(Player_Attributes.onRope){
                mAttr.player_Interaction.detachHingJoint();
            }
        }


    }

    //This only return whether the move is caused by user interaction
    void move(){
        //Need to be replaced with crossplatform Input manager
        updated_PlayerVelocity = new Vector2(translation_H*velocity_H,playerRB.velocity.y);
        playerRB.velocity = updated_PlayerVelocity;
 
    }

    void Jump()
    {
        updated_PlayerVelocity = new Vector2(playerRB.velocity.x, inAir_Velocity_V);
        playerRB.velocity = updated_PlayerVelocity;

    }

    // private void flipSprite()
    // {
    //     direction_H = (Mathf.Sign(playerRB.velocity.x));
    //     playerTF.localScale = new Vector2(direction_H, 1f);
    // }

    // private void attack(){
    //     Rigidbody2D clone;
    //     Vector3 attackPosition = new Vector3((transform.position.x+2*Mathf.Sign(transform.localScale.x)),transform.position.y,transform.position.z);
    //     clone = Instantiate(Attack, attackPosition, transform.rotation);
    // }


    //State Controll functiion
    void detectState(){
        onGround = playerCL.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void detectCanJump(){
        if(!onGround){
            canJump = false;
        }else{
            canJump = true;
        }
    }

    void detectCanIneract(){
        if(Player_Attributes.underAttack){
            canInteract = false;
            
            if((Time.time - Player_Attributes.timeAttacked) > recoveryTime){
                canInteract = true;
                Player_Attributes.underAttack = false;
            }
        }else if(ModeControl.mode_Aiming){
            canInteract = false;
        }else{
            canInteract = true;
        }
    }

    

    void velocity_Control(){
        inAir = !onGround;
        //TODO:Inair detection? what else situation besides not touching ground
        if(inAir){
            velocity_H = inAir_Velocity_H;
        }else{
            velocity_H = ground_Velocity_H;
        }
    }

    void animation_Control(){

        //TODO: inair and Jump condition should also be considered
        if(moving_Forced_H){
            Player_Animation.mAnimCon.changeAnim("Walking", true);
            // playerAN.SetBool("Walking", true);
        }else{
            // playerAN.SetBool("Walking",false);
            Player_Animation.mAnimCon.changeAnim("Walking", false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Player_Attributes.collidewith = other.gameObject;
    }

    

    
}
