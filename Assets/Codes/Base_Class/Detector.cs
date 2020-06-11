using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector
{

    //Using raycast or spherecast to determine 
    //Debug.drawline for visualization of ray



    public bool isOnGround(Collider2D mcollider){
        return mcollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    //This is only apply to horizontal detetction for now
    //The object should also be symmetric
    //Or put a empty trigger collider for edge 
    public bool approachEdge(GameObject gameObject, GameObject other, float edgeRange){
     
        float distanceToEdge;
        Bounds obBounds;
        Debug.Log("approachEdge()");

        obBounds = gameObject.GetComponent<Collider2D>().bounds;
        distanceToEdge = Mathf.Min(Mathf.Abs(gameObject.transform.position.x - obBounds.min.x), Mathf.Abs(gameObject.transform.position.x - obBounds.max.x));
        
        if( distanceToEdge > edgeRange){
            return false;

        }else{
            //at Edge
            return true;
        }

    }
}
