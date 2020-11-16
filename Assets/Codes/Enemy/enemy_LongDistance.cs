using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_LongDistance : MonoBehaviour
{
    bool shooting;
    Vector2 shootDirection;
    void Start()
    {
        
    }

    void Update(){
        
    }

    private void FixedUpdate() {
        // shoot direcction should be instantnously updated
    }

    void shoot(){

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            shoot();
        }
    }
}
