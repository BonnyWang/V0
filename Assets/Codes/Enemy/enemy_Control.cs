using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Control : MonoBehaviour
{
    //Enemy Property
    int health;
    

    void Start()
    {
        health = 9;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Substring(0,6) == "Attack"){
            health -= 3;
            
        }
    }
}
