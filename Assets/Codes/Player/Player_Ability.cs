using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability : MonoBehaviour
{
    bool y_Aim_Down;
    bool y_Aim_Up;
    Transform selected;
    [SerializeField] float angleTimeScale = 0.1f;
    [SerializeField] float angleTimePeriod = 5f;

    // Element prefabs to throw
    Rigidbody2D clone;
    [SerializeField] Rigidbody2D waterBall;

    // If ability is direction need 
    float attackDirection;
    Vector3 attackPosition;
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
            start_AngleTime();
        }

        y_Aim_Up = Input.GetButtonUp("Aim");
        if(y_Aim_Up){
            ModeControl.mode_Aiming = false;
            stop_AngleTime();
        }

        if(selected != null){
            selected.localScale = new Vector3(1,1,1);
            if(ModeControl.mode_Aiming ==false){
                // 
            }else{
                // still in aiming mode the selected would be the new targe
                selected = null;
            } 
        }

        if(Input.GetButtonDown("Skill")){
            if(selected != null){
                castAbility(selected.gameObject);
            }
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
            
            Debug.DrawRay(transform.position, direction,Color.green);
            hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity,LayerMask.GetMask("Element"));
            if(hit.collider != null){
                selected = hit.transform;
                selected.localScale = new Vector3(2,2,2);
            }           

        }

    }

    void castAbility(GameObject selected){
        if(selected.transform.tag == "Rope"){
            selected.transform.parent.GetComponent<Rope>().constructRope();
            Debug.Log("ConstructRope");
        }

        if(selected.transform.tag == "Water"){
            attackDirection = Mathf.Sign(transform.localScale.x);
            attackPosition = new Vector3((transform.position.x+2*attackDirection),transform.position.y,transform.position.z);
            clone = Instantiate(waterBall, attackPosition, transform.rotation);
            Vector2 shootForce = new Vector2(attackDirection*500, 100);
            clone.AddForce(shootForce);
        }
    }

    void start_AngleTime(){
        Time.timeScale = angleTimeScale;
    }

    void stop_AngleTime(){
        Time.timeScale = 1f;
    }
}
