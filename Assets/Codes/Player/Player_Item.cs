﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Substring(0,4) == "item"){
            Destroy(other.gameObject);
            Backpack.addObject(other.gameObject.tag);
            Debug.Log("itemCollected");
        }
    }
}
