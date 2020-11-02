using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] GameObject skillSelection;
    protected GameObject tempSkillSelection;
    public virtual void castElement() {}
    public virtual void showDirection(){
        Detector.getInputDirection(transform);
        if(tempSkillSelection == null){
            tempSkillSelection = Instantiate(skillSelection, transform);
        }
    }

    private void Awake() {
        player = GameObject.Find("Player");
    }

    public void removeSkillSelection(){
        Destroy(tempSkillSelection);
    }


}
