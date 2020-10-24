using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    Player_Attributes mAttr;

    HingeJoint2D playerHingeJoint;
    Rope rope;

    private void Start() {
        mAttr = GetComponent<Player_Attributes>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Rope"){
            if(!Player_Attributes.onRope){
                // Add HingeJoint to player and connected it to the rope
                playerHingeJoint = gameObject.AddComponent<HingeJoint2D>();
                playerHingeJoint.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
                playerHingeJoint.autoConfigureConnectedAnchor = false;
                playerHingeJoint.anchor = new Vector2(0,0);
                playerHingeJoint.connectedAnchor = new Vector2(0,0);

                rope = other.transform.parent.GetComponent<Rope>();
                rope.setChildRB(false);

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
}
