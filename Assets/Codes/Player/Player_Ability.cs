using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability : MonoBehaviour
{
    // bool y_Aim_Down;
    // bool y_Aim_Up;
    Transform selected;
    [SerializeField] float angleTimeScale = 0.07f;
    [SerializeField] float angleTimePeriod = 5f;
    [SerializeField] float abilityCoolingPeriod = 5f;
    [SerializeField] float elementRange = 1f;

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

        if(!ModeControl.ability_Cooling){
            inputDetect();
        }

        

        if(ModeControl.mode_Aiming){
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, getInputDirection(transform), elementRange,LayerMask.GetMask("Element"));
            if(hit.collider != null && hit.transform.parent.GetComponent<ElementControl>().canUse){
                if(selected != hit.transform){
                    if(selected != null){
                        indicateChoice(selected, true);
                    }
                    selected = hit.transform;
                    indicateChoice(selected,false);
                }else{
                    // selected is still the old one no action required
                }
            }else{
                // does not hit anything or not element
                if(selected != null){
                    indicateChoice(selected,true);
                }

                selected = null;
            }           
        }

        if(ModeControl.skill_Aiming){
            getInputDirection(selected.transform);
        }

    }

    void inputDetect(){
        if(Input.GetButtonDown("Aim")){
            ModeControl.mode_Aiming = true;
            start_AngleTime();
        }

        if(Input.GetButtonUp("Aim")){
            ModeControl.mode_Aiming = false;
            if(selected == null){
                stop_AngleTime();
            }
        }


        if(Input.GetButtonDown("Skill")){
            if(selected != null){
                castAbility();
            }
        }

        if(ModeControl.skill_Aiming && Input.GetButtonUp("Skill")){
            ModeControl.skill_Aiming = false;
            castAbility(true);
        }

    }

    void castAbility(bool release = false){
        if(selected.transform.tag == "Rope"){
            selected.parent.GetComponent<Rope>().constructRope();
            Debug.Log("ConstructRope");
            selected.parent.GetComponent<ElementControl>().usedElement();
            selected = null;
            stop_AngleTime();
        }else if(selected.transform.tag == "Water"){
            if(release == true){
                attackPosition = new Vector3((selected.position.x+2*Mathf.Sign(getInputDirection(selected).x)),selected.position.y,selected.position.z);
                clone = Instantiate(waterBall, attackPosition, transform.rotation);
                Vector2 shootForce = getInputDirection(selected.transform)*100;
                clone.AddForce(shootForce);
                stop_AngleTime();
                selected.parent.GetComponent<ElementControl>().usedElement();
                selected = null;
            }else{
                ModeControl.skill_Aiming = true;
            }
        }else{
            stop_AngleTime();
        }
    }

    void start_AngleTime(){
        Time.timeScale = angleTimeScale;
        StartCoroutine(countAngleTime());
    }

    void stop_AngleTime(){
        Time.timeScale = 1f;
    }

    Vector2 getInputDirection(Transform origin){
        Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 direction = (Vector2)(mouseray.origin - origin.position);    
        if((Input.GetAxis("Horizontal") != 0)|(Input.GetAxis("Vertical") != 0)){
            // if from controller;
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            // this is just for debug purpose to make the ray more visible
            direction *= 10f;
        }
        
        Debug.DrawRay(origin.position, direction,Color.green);
        return direction;
            
    }
    void indicateChoice(Transform ps, bool psState){
        
        if(psState){
            ps.parent.Find("PS").GetComponent<ParticleSystem>().Emit(1);
            ps.parent.Find("PS").GetComponent<ParticleSystem>().Play();
            
        }else{
            ps.parent.Find("PS").GetComponent<ParticleSystem>().Pause();
        }
    }

    IEnumerator countAngleTime(){
        yield return new WaitForSecondsRealtime(angleTimePeriod);
        if(Time.timeScale != 1f){
            // If user waited too long and did not cast ability
            stop_AngleTime();
            ModeControl.mode_Aiming = false;
            ModeControl.skill_Aiming = false;
            if(selected != null){
                indicateChoice(selected, true);
            }
            selected = null;
            ModeControl.ability_Cooling = true;
        }

        StartCoroutine(abilityCooling());
    }

    IEnumerator abilityCooling(){
        yield return new WaitForSecondsRealtime(abilityCoolingPeriod);
        ModeControl.ability_Cooling = false;
    }

}
