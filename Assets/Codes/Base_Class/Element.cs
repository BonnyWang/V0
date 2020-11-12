using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    protected ElementControl elementControl;
    protected GameObject player;
    public GameObject skillSelection;
    public GameObject Arrow;
    protected GameObject mArrow;
    protected GameObject tempSkillSelection;
    public GameObject previousElement;
    public GameObject nextElement;
    public virtual void castElement() {}
    public virtual void showDirection(){
        if(elementControl.canUse){
            Vector2 dir = Detector.getInputDirection(transform);
            Destroy(mArrow);
            mArrow  = Instantiate(Arrow, this.transform);
            mArrow.transform.position = new Vector3(transform.position.x+2*dir.x,transform.position.y+2*dir.y,transform.position.z);
            mArrow.transform.up = dir;
        }
        if(tempSkillSelection == null){
            tempSkillSelection = Instantiate(skillSelection, transform);
        }
    }

    private void Awake() {
        player = GameObject.Find("Player");
        elementControl = GetComponent<ElementControl>();
    }

    public void removeSkillSelection(){
        Destroy(tempSkillSelection);
        Destroy(mArrow);
    }


}
