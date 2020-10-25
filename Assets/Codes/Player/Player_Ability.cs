using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability : MonoBehaviour
{
    bool y_Aim_Down;
    bool y_Aim_Up;
    Transform selected;
    void Start()
    {
        selected = null;
    }

    // Update is called once per frame
    void Update()
    {
        y_Aim_Down = Input.GetButtonDown("Aim");
        if(y_Aim_Down){
            ModeControl.mode_Aiming = true;
        }

        y_Aim_Up = Input.GetButtonUp("Aim");
        if(y_Aim_Up){
            ModeControl.mode_Aiming = false;
        }

        if(selected != null){
            selected.localScale = new Vector3(1,1,1);
            if(ModeControl.mode_Aiming ==false){
                if(selected.transform.tag == "Rope"){
                    selected.transform.parent.GetComponent<Rope>().constructRope();
                    Debug.Log("ConstructRope");
                }
            } 
            selected = null;
        }


        if(ModeControl.mode_Aiming){
            Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit;
            Vector2 direction = (Vector2)(mouseray.origin - transform.position);    
            if((Input.GetAxis("Horizontal") != 0)|(Input.GetAxis("Vertical") != 0)){
                // if from controller;
                direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                // this is just for debug purpose to make the ray more visible
                direction *= 10f;
            }
            
            Debug.DrawRay(transform.position, direction,Color.green,1f);
            hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity,LayerMask.GetMask("Element"));
            if(hit.collider != null){
                selected = hit.transform;
                selected.localScale = new Vector3(2,2,2);
            }           

        }

    }
}
