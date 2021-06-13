using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodElement : Element
{
    [SerializeField] float player_InitSwingForce = 2000f;
    [SerializeField] float ropeReachStep = 0.1f;
    [SerializeField] float ropeSwingStep = 0.1f;
    [SerializeField] float dashForce = 30f;
    GameObject lastChild;
    float ropeLength;
    Vector2 tempDir;
    Vector2 targetPosition;
    bool swing;
    bool reach;

    bool outLimit;

    private void Start() {
        reach = false;
        swing = false;
        outLimit = false;

    }
    
    public override void castElement(){
        skill_Rope();
    }

    private void FixedUpdate() {
        if(reach){
            lastChild = transform.GetChild(transform.childCount - 1).gameObject;

            lastChild.transform.position = Vector2.MoveTowards(lastChild.transform.position,player.transform.position, ropeReachStep);
            if(lastChild.transform.position == player.transform.position & !swing){
                player.GetComponent<Player_Interaction>().connectPlayer_Rope(lastChild);
                reach = false;
            }
        }
        
        if(swing){     
            // should also check if player is on rope to 
            if(Vector2.Distance((Vector2)player.transform.position, targetPosition) > 0.5f){
                Debug.DrawLine(targetPosition,player.transform.position,Color.red, 100);
                player.GetComponent<Rigidbody2D>().gravityScale = 0;
                player.GetComponent<Rigidbody2D>().velocity = (targetPosition-(Vector2)player.transform.position )*dashForce;
                // player.GetComponent<Rigidbody2D>().AddForce((targetPosition-(Vector2)player.transform.position )*dashForce,ForceMode2D.Impulse);
                
            }else{
                swing = false;
                player.GetComponent<Rigidbody2D>().gravityScale = 3f;
                GetComponent<Rope>().setGravityforChilds(3f);
                // player.GetComponent<Player_Interaction>().connectPlayer_Rope(lastChild);
            }
        }
    }


    void skill_Rope(){
        tempDir = Detector.getInputDirection(transform).normalized;
        GetComponent<Rope>().constructRope();
        GetComponent<Rope>().setGravityforChilds(0f);

        if(player.GetComponent<HingeJoint2D>()!=null){
            player.GetComponent<Player_Interaction>().detachHingJoint();
        }
        
        ropeLength = 5f;
        targetPosition = new Vector2(transform.position.x,transform.position.y) + ropeLength*tempDir;
        swing = true;
        reach = true;
        StartCoroutine(reachCountDown());

    }

    IEnumerator reachCountDown(){
        yield return new WaitForSecondsRealtime(1f);
        outLimit = true;
        yield break;
    }

    bool validAngle(Vector2 tempDir){

        if(Mathf.Rad2Deg*Mathf.Atan2(Mathf.Abs(tempDir.x),Mathf.Abs(tempDir.y)) < 60){
            if(tempDir.y < 0){
                return true;
            }
        }
        
        return false;
    }
}
