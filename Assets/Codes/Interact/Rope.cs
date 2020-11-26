using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    [SerializeField] int Length;
    [SerializeField] GameObject ropePiece;
    [SerializeField] float ropeLife;

    // Start is called before the first frame update
    void Start(){
    }

    public void setLastChildCollider(bool state){
        transform.GetChild(transform.childCount -1).GetComponent<Collider2D>().enabled = state;
    }

    public void constructRope(){
        if(transform.childCount < Length){
            // prevent contruct multiple times
            GameObject[] rope = new GameObject[Length];
            rope[0] = Instantiate(ropePiece, transform);
            rope[0].GetComponent<HingeJoint2D>().connectedBody = transform.Find("SpritePoint").GetComponent<Rigidbody2D>();
            Destroy(rope[0],ropeLife);
            
            for(int i= 1; i < Length; i++){
                rope[i] = Instantiate(ropePiece, transform);
                rope[i].GetComponent<HingeJoint2D>().connectedBody = rope[i - 1].GetComponent<Rigidbody2D>();
                rope[i].GetComponent<HingeJoint2D>().anchor = new Vector2(0,0.2f);

                Destroy(rope[i],ropeLife);
            }

            // add extra mass to the end of the rope
            rope[Length-1].GetComponent<Rigidbody2D>().mass = 3f;  
            rope[Length-1].GetComponent<Collider2D>().isTrigger = true;
            rope[Length-1].tag = "Rope";
        } 
    }

}
