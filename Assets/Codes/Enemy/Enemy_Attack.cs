using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    // AnimCon mAnimCon;
    [SerializeField] GameObject player;
    [SerializeField] float AttackDistance;

    Enemy_Attributes mAttr;

    void Start()
    {
        //  mAnimCon = new AnimCon(GetComponent<Animator>());
        mAttr = GetComponent<Enemy_Attributes>();
    }

    private void Update() {
        detectPlayer();
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            mAttr.mAnimCon.backBounce(gameObject,other.gameObject);
            Debug.Log("Enemy Debounced");
        }
    }

    void detectPlayer(){
        if(Mathf.Abs(Vector3.Distance(player.transform.position,transform.position)) < AttackDistance){
            Debug.Log("Enemy Detected Player");
            mAttr.relativeDir = Mathf.Sign( player.transform.position.x - transform.position.x);
            followPlayer();

        }
        
    }

    void followPlayer(){
        mAttr.mRigidBody.velocity = new Vector2( mAttr.velocity_H*mAttr.relativeDir, mAttr.mRigidBody.velocity.y);
    }
}
