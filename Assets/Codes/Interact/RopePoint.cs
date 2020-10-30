using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePoint : MonoBehaviour
{
    GameObject player;
    private void Start() {
        player = GameObject.Find("Player");
    }
   private void OnDestroy() {
       if(player != null){
           if(player.GetComponent<HingeJoint2D>() != null){
               if(player.GetComponent<HingeJoint2D>().connectedBody == GetComponent<Rigidbody2D>()){
                    player.GetComponent<Player_Interaction>().detachHingJoint();
                }
           }
       }    
   }
}
