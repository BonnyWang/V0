using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    AnimCon mAnimCon;
    void Start()
    {
        mAnimCon = new AnimCon(GetComponent<Animator>());
    }

    private void Update() {
        
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            mAnimCon.backBounce(gameObject,other.gameObject);
            Debug.Log("Enemy Debounced");
        }
    }

    void detectPlayer(){
        
    }
}
