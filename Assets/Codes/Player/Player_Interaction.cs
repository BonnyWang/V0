using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    Player_Attributes mAttr;

    HingeJoint2D playerHingeJoint;
    Rope rope;
    Transform interactedObj;
    public Transform discardRope;

    private void Start() {
        mAttr = GetComponent<Player_Attributes>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Rope"){
            connectPlayer_Rope(other.gameObject);
        }

    }

    public void connectPlayer_Rope(GameObject mrope){
        if(gameObject.GetComponent<HingeJoint2D>() != null){
            Destroy(gameObject.GetComponent<HingeJoint2D>());
            Player_Attributes.onRope = false;
        }

        if(!Player_Attributes.onRope && discardRope != mrope.transform.parent){
                // Add HingeJoint to player and connected it to the rope
                
                playerHingeJoint = gameObject.AddComponent<HingeJoint2D>();
                playerHingeJoint.connectedBody = mrope.GetComponent<Rigidbody2D>();
                playerHingeJoint.autoConfigureConnectedAnchor = false;
                playerHingeJoint.anchor = new Vector2(0,0);
                playerHingeJoint.connectedAnchor = new Vector2(0,0);

                rope = mrope.transform.parent.GetComponent<Rope>();
                rope.setLastChildCollider(false);

                interactedObj = mrope.transform;

                Player_Attributes.onRope = true;
        }
    }


    public void detachHingJoint(){
        playerHingeJoint = GetComponent<HingeJoint2D>();
        if(playerHingeJoint != null){
            discardRope = playerHingeJoint.connectedBody.transform.parent;
            Destroy(playerHingeJoint);
            Player_Attributes.onRope = false;
        }
    }

    public void setRopeActive(){
        // Set the climbed rope back to active
        rope.setLastChildCollider(true);
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

    public void clearDiscardRope(){
        discardRope = null;
    }

}
