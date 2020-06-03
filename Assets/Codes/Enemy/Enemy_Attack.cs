using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    AnimCon mAnimCon;
    [SerializeField] GameObject player;
    [SerializeField] float AttackDistance;

    Enemy_Attributes mAttr;

    void Start()
    {
        mAnimCon = new AnimCon(GetComponent<Animator>());
        mAttr = GetComponent<Enemy_Attributes>();
    }

    private void Update() {
        detectPlayer();
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            mAnimCon.backBounce(gameObject,other.gameObject);
            Debug.Log("Enemy Debounced");
        }
    }

    void detectPlayer(){
        if(Mathf.Abs(Vector3.Distance(player.transform.position,transform.position)) < AttackDistance){
            Debug.Log("Enemy Detected Player");
            followPlayer();
        }
        
    }

    void followPlayer(){
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,0.01f);
    }
}
