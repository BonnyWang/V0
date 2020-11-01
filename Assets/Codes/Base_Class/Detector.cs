using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector:MonoBehaviour
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

        public static Vector2 getInputDirection(Transform origin){
        Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 direction = (Vector2)(mouseray.origin - origin.position);    
            if((Input.GetAxis("Horizontal") != 0)|(Input.GetAxis("Vertical") != 0)){
                // if from controller;
                direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                // this is just for debug purpose to make the ray more visible
                direction *= 10f;
            }
        
        Debug.DrawRay(origin.position, direction,Color.green);
        return direction;
            
        }
}
