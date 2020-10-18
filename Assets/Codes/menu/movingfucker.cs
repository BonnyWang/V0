using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingfucker : MonoBehaviour
{
    private bool a = true;


    void Update()
    {
        if (gameObject.transform.position.x > 500)
        {
            a = false;
        }
        if (gameObject.transform.position.x < -500)
        {
            a = true;
        }
        if (a)
        {
            transform.Translate(100 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-100 * Time.deltaTime, 0, 0);
        }
        
    }
}
