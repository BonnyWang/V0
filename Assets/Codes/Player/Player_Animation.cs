using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    Player_Attributes mAttr;
    [SerializeField] Vector2 backOff;
    
    void Start()
    {
        mAttr = GetComponent<Player_Attributes>();
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Enemy"){
            
            mAttr.mAnimCon.backBounce(gameObject,other.gameObject,backOff);
            Player_Attributes.underAttack = true;
            Player_Attributes.timeAttacked = Time.time;
        }
    }
}
