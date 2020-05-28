using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_Controll : MonoBehaviour
{
    float duration;
    void Start()
    {
        if(gameObject.tag == "Attack"){
            duration = 0.3f;
        }
        if(gameObject.tag == "AttackLong"){
            duration = 1f;
        }
        Destroy(gameObject,duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
