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
            if((Vector2)lastChild.transform.position != targetPosition){
                lastChild.transform.position = Vector2.MoveTowards(lastChild.transform.position,targetPosition, ropeSwingStep);
                
            }else{
                swing = false;
            }
        }
    }


    void skill_Rope(){
        tempDir = Detector.getInputDirection(transform).normalized;
        if(validAngle()){
            GetComponent<Rope>().constructRope();
            lastChild = transform.GetChild(transform.childCount - 1).gameObject;
            ropeLength = Mathf.Abs(transform.childCount*lastChild.GetComponent<HingeJoint2D>().connectedAnchor.y);
            targetPosition = new Vector2(transform.position.x,transform.position.y) + ropeLength*tempDir;
            reach = true;
        }
    }

    IEnumerator swingCountDown(){
        yield return new WaitForSecondsRealtime(1f);
        swing = false;
    }

    bool validAngle(){

        if(Mathf.Atan2(Mathf.Abs(tempDir.x),Mathf.Abs(tempDir.y)) < Mathf.PI/3){
            if(tempDir.y < 0){
                return true;
            }
        }
        
        return false;
    }
}
