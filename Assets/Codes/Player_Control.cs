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
    bool direction_H;

    //Properties
    Rigidbody2D playerRB;
    Transform playerTF;
    
    //Properties to be Adjusted
    [SerializedField] float velocity = 1f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerTF = GetComponent<Transform>();
    }

    void Update()
    {
        //Should Input Axis be detected here or in each seperate function? use if value to test?
        translation_H =  Input.GetAxis("Horizontal");
        if(move()){
            if(Mathf.Sign(playerRB.velocity.x) != translation_H ){
                flipSprite();
            }
        }


    }

    //This only return whether the move is caused by user interaction
    bool move(){
        //Need to be replaced with crossplatform Input manager
        if(abs(translation_H)>0){
            Updated_playerVelocity = new Vector2(translation_H,playerRB.velocity.y);
            playerRB.velocity = playerVelocity;
            return true;
        }

        return false;
        
    }

    void jump(){
        translation_V = Input.GetAxis("Vertical");

    }

     private void flipSprite()
    {
        direction_H = (Mathf.Sign(playerRB.velocity.x));
        playerTF.localScale = new Vector2(RightorLeft, 1f);
        //playerAN.SetBool("Running", goingRightorLeft);
    }
}
