using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    Player_Attributes mAttr;

    HingeJoint2D playerHingeJoint;
    Rope rope;
    Transform interactedObj;

    private void Start() {
        mAttr = GetComponent<Player_Attributes>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Rope"){
            if(!Player_Attributes.onRope){
                // Add HingeJoint to player and connected it to the rope
                if(gameObject.GetComponent<HingeJoint2D>() == null){
                    playerHingeJoint = gameObject.AddComponent<HingeJoint2D>();
                }
                playerHingeJoint.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
                playerHingeJoint.autoConfigureConnectedAnchor = false;
                playerHingeJoint.anchor = new Vector2(0,0);
                playerHingeJoint.connectedAnchor = new Vector2(0,0);

                rope = other.transform.parent.GetComponent<Rope>();
                rope.setChildRB(false);

                interactedObj = other.transform;

                Player_Attributes.onRope = true;
            }
            
        }

    }

    public void detachHingJoint(){
        playerHingeJoint = GetComponent<HingeJoint2D>();
        if(playerHingeJoint != null){
            Destroy(playerHingeJoint);
        }
    }

    public void setRopeActive(){
        // Set the climbed rope back to active
        rope.setChildRB(true);
    }

    public void moveUpRope(){
        playerHingeJoint = GetComponent<HingeJoint2D>();
        int index = interactedObj.GetSiblingIndex();
        if(index > 2){
            interactedObj = interactedObj.transform.parent.GetChild(index - 1);
        }
        playerHingeJoint.connectedBody = interactedObj.GetComponent<Rigidbody2D>();
    }

    public void moveDownRope(){
        playerHingeJoint = GetComponent<HingeJoint2D>();
        int index = interactedObj.GetSiblingIndex();
        if(index< (interactedObj.transform.parent.childCount - 1)){
            interactedObj = interactedObj.transform.parent.GetChild(index + 1);
        }
        
        playerHingeJoint.connectedBody = interactedObj.GetComponent<Rigidbody2D>();
    }

}
