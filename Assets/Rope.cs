using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    [SerializeField] int Length;
    [SerializeField] GameObject ropePiece;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] rope = new GameObject[Length];
        rope[0] = Instantiate(ropePiece, transform);
        rope[0].GetComponent<HingeJoint2D>().connectedBody = transform.Find("RopePoint").GetComponent<Rigidbody2D>();
        
        for(int i= 1; i < Length; i++){
            rope[i] = Instantiate(ropePiece, transform);
            rope[i].GetComponent<HingeJoint2D>().connectedBody = rope[i - 1].GetComponent<Rigidbody2D>();
            rope[i].GetComponent<HingeJoint2D>().anchor = new Vector2(0,0.5f);
        }

        rope[Length-1].GetComponent<Rigidbody2D>().mass = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
