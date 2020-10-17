﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Control : MonoBehaviour
{
    //Enemy Property
    int health;
    Enemy_Attributes mAttr;
    

    void Start()
    {
        health = 9;
        mAttr = GetComponent<Enemy_Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }

        // mAttr.mAnimCon.flipSprite(transform);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Substring(0,6) == "Attack"){
            health -= 3;
            
        }
    }
}
