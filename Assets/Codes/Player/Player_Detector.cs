﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detector : Detector
{
    [SerializeField] float edgeRange;
    Player_Attributes mAttr;
    void Start()
    {
        mAttr = GetComponent<Player_Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        // mAttr.isOnGround = mAttr.mDetector.isOnGround(mAttr.mCollider);
    }

    /*
    private void OnCollisionEnter2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer) == "Ground"){
            if( mAttr.mDetector.approachEdge(gameObject, other.gameObject,edgeRange)){
                Debug.Log("Approach Edge");
            }
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer ) == "Ground"){
             mAttr.isOnGround = true;
             if(mAttr.player_Interaction.discardRope != null){
                mAttr.player_Interaction.clearDiscardRope();
                mAttr.player_Interaction.setRopeActive();
             }

             if(mAttr.mAnimCon.getVariable("Jumped")){
                mAttr.mAnimCon.changeAnim("Jumped",false);
             }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer ) == "Ground"){
             mAttr.isOnGround = false;
        }
    }
}
