using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    [SerializeField] int Length;
    [SerializeField] GameObject ropePiece;
    [SerializeField] float ropeLife;

    public LineRenderer lr; 
    GameObject[] rope;

    // Start is called before the first frame update
    void Start(){
        // constructRope();
        lr = GetComponent<LineRenderer>();
    }

    private void Update() {
        if(transform.childCount > 5){
            renderLine();
        }else{
            lr.positionCount = 0;
        }
    }

    public void setLastChildCollider(bool state){
        transform.GetChild(transform.childCount -1).GetComponent<Collider2D>().enabled = state;
    }

    public void setGravityforChilds(float scale){
        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        for(int i = 0; i < rbs.Length;i++){
            rbs[i].gravityScale = scale;
        }

    }

    public void constructRope(){
        if(transform.childCount < Length){
            // prevent contruct multiple times
            rope = new GameObject[Length];
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

    void renderLine(){
        lr.positionCount = Length;
        for(int i = 0 ;i < Length;i++){
            lr.SetPosition(i, rope[i].transform.position);
        }
    }

}
