using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    //Variables
    //Movement
    float translation_H;
    float translation_V;
    Vector2 updated_PlayerVelocity;
    //Mode
    bool inAir;
    bool canJump;
    float direction_H;

    //Properties
    Rigidbody2D playerRB;
    Transform playerTF;
    CapsuleCollider2D playerCL;
    
    //Properties to be Adjusted
    [SerializeField] float velocity_H = 1f;
    [SerializeField] float inAir_Velocity_H = 1.5f;
    [SerializeField] float inAir_Velocity_V = 5f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerTF = GetComponent<Transform>();
        playerCL = GetComponent<CapsuleCollider2D>();

        canJump = true;
    }

    void Update()
    {
        //Interaction Detect
        translation_H =  Input.GetAxis("Horizontal");
        translation_V = Input.GetAxis("Vertical");

        //Mode Detect
        //onGround = playerCL.IsTouchingLayers(LayerMask.GetMask("Ground"));
        velocity_Control();


        //Interaction Control(can be a function later)
        if(Mathf.Abs(translation_H)>0){
            
            if(Mathf.Sign(playerRB.velocity.x) != translation_H ){
                flipSprite();
            }

            move();
        }

        if(translation_V>0){
            Jump();
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
        if (canJump)
        {
            updated_PlayerVelocity = new Vector2(playerRB.velocity.x, translation_V*inAir_Velocity_V);
            playerRB.velocity = updated_PlayerVelocity;
        }
    }

     private void flipSprite()
    {
        direction_H = (Mathf.Sign(playerRB.velocity.x));
        playerTF.localScale = new Vector2(direction_H, 1f);
        //playerAN.SetBool("Running", goingRightorLeft);
    }

    void detectCanJump(){
        //if --> canJump = true
    }


    void velocity_Control(){
        if(inAir){
            velocity_H = inAir_Velocity_H;
        }
    }
}
