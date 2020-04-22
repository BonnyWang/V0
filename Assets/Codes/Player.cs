using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");//1~-1
        Vector2 playerVelocity = new Vector2(controlThrow * speed,playerRB.velocity.y);
        playerRB.velocity = playerVelocity;

    }
}
