using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ability : MonoBehaviour
{

    Transform selected;
    Element selectedElement;
    [SerializeField] float angleTimeScale = 0.07f;
    [SerializeField] float angleTimePeriod = 5f;
    [SerializeField] float abilityCoolingPeriod = 5f;
    [SerializeField] float elementRange = 1f;
    [SerializeField] GameObject angelTimeShade;


    Player_Attributes mAttr;

    void Start()
    {
        selected = null;
        mAttr = GetComponent<Player_Attributes>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!ModeControl.ability_Cooling){
            inputDetect();
        }


        if(ModeControl.mode_Aiming){
            selecting();
        }

        if(ModeControl.skill_Aiming){
            selected.parent.GetComponent<Element>().showDirection();
            changElement();
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
            }else{
                ModeControl.skill_Aiming = true;
                selectedElement = selected.parent.GetComponent<Element>();
            }
        }


        if(Input.GetButtonDown("Skill")){
            if(selected != null){
                castAbility();
            }
        }
    }

    void changElement(){
        if(Input.GetButtonDown("Next")){
            if(selected.parent.GetComponent<Element>().nextElement !=null){
                selectedElement.removeSkillSelection();
                indicateChoice(selected, true);
                selected = selected.parent.GetComponent<Element>().nextElement.transform;
                selectedElement = selected.parent.GetComponent<Element>();
                indicateChoice(selected, false);
                selectedElement.showDirection();
            }
            
        }
        if(Input.GetButtonDown("Previous")){
             if(selected.parent.GetComponent<Element>().previousElement !=null){
                selectedElement.removeSkillSelection();
                indicateChoice(selected, true);
                selected = selected.parent.GetComponent<Element>().previousElement.transform;
                selectedElement = selected.parent.GetComponent<Element>();
                indicateChoice(selected, false);
                selectedElement.showDirection();
            }
        }
    }

    void selecting(){
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Detector.getInputDirection(transform), elementRange,LayerMask.GetMask("Element"));
        if(hit.collider != null && hit.transform.parent.GetComponent<ElementControl>().canUse){
            // hit valid collider
            if(selected != hit.transform){
                if(selected != null){
                    // set the previous selected ps back to motion
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
                // set the previous ps back to motion
                indicateChoice(selected,true);
            }
            selected = null;
        }           
    }

    void castAbility(){
        stop_AngleTime();
        ModeControl.skill_Aiming = false;
        if(selected.parent.GetComponent<ElementControl>().canUse){
            selected.parent.GetComponent<ElementControl>().usedElement();
            selected.parent.GetComponent<Element>().removeSkillSelection();
            selected.parent.GetComponent<Element>().castElement();
            selected = null;
        }
    }

    void start_AngleTime(){
        Time.timeScale = angleTimeScale;
        StartCoroutine(countAngleTime());
        angelTimeShade.SetActive(true);
    }

    void stop_AngleTime(){
        Time.timeScale = 1f;
        angelTimeShade.SetActive(false);
        StopAllCoroutines();
    }


    void indicateChoice(Transform selected, bool psState){
        
        if(psState){
            selected.parent.Find("PS").GetComponent<ParticleSystem>().Emit(1);
            selected.parent.Find("PS").GetComponent<ParticleSystem>().Play();
            
        }else{
            selected.parent.Find("PS").GetComponent<ParticleSystem>().Pause();
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
                selected.parent.GetComponent<Element>().removeSkillSelection();
            }
            selected = null;
            ModeControl.ability_Cooling = true;
        }

        StartCoroutine(abilityCooling());
        yield break;
    }

    IEnumerator abilityCooling(){
        yield return new WaitForSecondsRealtime(abilityCoolingPeriod);
        ModeControl.ability_Cooling = false;
        yield break;
    }

}
