using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    const int NOMASKMODE = 0;

    //TO hold different attack
    [SerializeField] Rigidbody2D xAttack;
    [SerializeField] Rigidbody2D shootAttack;

    float attackDirection;
    Vector3 attackPosition;

    Rigidbody2D clone;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(Player_Attributes.attackMode == NOMASKMODE){
                //Do nothing when no mask
            }else{
                attackDirection = Mathf.Sign(transform.localScale.x);
                attackPosition = new Vector3((transform.position.x+2*attackDirection),transform.position.y,transform.position.z);

                if(Player_Attributes.attackMode == 1){
                    xattack();
                }

                if(Player_Attributes.attackMode == 2){
                    xlongattack();
                }
            }
            
            
        }
    }

    void xattack(){
        clone = Instantiate(xAttack, attackPosition, transform.rotation);
        clone.transform.parent = gameObject.transform;
    }

    void xlongattack(){
        clone = Instantiate(shootAttack, attackPosition, transform.rotation);
        Vector2 shootForce = new Vector2(attackDirection*500, 100);
        clone.AddForce(shootForce);
    }

    
}
