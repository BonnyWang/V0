using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            if(Player_Attributes.attackMode == 0){
                Debug.Log("attackmode0");
            }
            
            if(Player_Attributes.attackMode == 1){
                Debug.Log("Mask Attack");
            }
        }
    }
}
