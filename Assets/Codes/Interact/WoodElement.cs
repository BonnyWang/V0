using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodElement : Element
{
    [SerializeField] float player_InitSwingForce = 2000f;
    [SerializeField] float ropeReachStep = 0.1f;
    [SerializeField] float ropeSwingStep = 0.1f;
    GameObject lastChild;
    float ropeLength;
    Vector2 tempDir;
    Vector2 targetPosition;
    bool swing;
    bool reach;

    private void Start() {
        reach = false;
        swing = false;

    }
    
    public override void castElement(){
        skill_Rope();
    }

    private void Update() {
        if(reach){
            lastChild.transform.position = Vector2.MoveTowards(lastChild.transform.position,player.transform.position, ropeReachStep);
            if(lastChild.transform.position == player.transform.position){
                player.GetComponent<Player_Interaction>().connectPlayer_Rope(lastChild);
                reach = false;
                swing = true;
                // StartCoroutine(swingCountDown());
            }
        }
        
        if(swing){     
            // if((Vector2)lastChild.transform.position != targetPosition){
                lastChild.GetComponent<Rigidbody2D>().AddForce(tempDir*200,ForceMode2D.Impulse);
                
            // }else{
                swing = false;
            // }
        }
    }


    void skill_Rope(){
        tempDir = Detector.getInputDirection(transform).normalized;
        // if(validAngle(tempDir)){
            GetComponent<Rope>().constructRope();
            lastChild = transform.GetChild(transform.childCount - 1).gameObject;
            ropeLength = Mathf.Abs(transform.childCount*lastChild.GetComponent<HingeJoint2D>().connectedAnchor.y);
            targetPosition = new Vector2(transform.position.x,transform.position.y) + ropeLength*tempDir;
            reach = true;
        // }
    }

    IEnumerator swingCountDown(){
        yield return new WaitForSecondsRealtime(1f);
        swing = false;
    }

    bool validAngle(Vector2 tempDir){

        if(Mathf.Rad2Deg*Mathf.Atan2(Mathf.Abs(tempDir.x),Mathf.Abs(tempDir.y)) < 60){
            if(tempDir.y < 0){
                return true;
            }
        }
        
        return false;
    }

    // public override void showDirection(){
    //     Vector2 dir = Detector.getInputDirection(transform);
    //     if(validAngle(dir)){
    //         Destroy(mArrow);
    //         mArrow  = Instantiate(Arrow, this.transform);
    //         mArrow.transform.position = new Vector3(transform.position.x+2*dir.x,transform.position.y+2*dir.y,transform.position.z);
    //         mArrow.transform.up = dir;
    //         if(tempSkillSelection == null){
    //             tempSkillSelection = Instantiate(skillSelection, transform);
    //         }
    //     } 
    // }
}
