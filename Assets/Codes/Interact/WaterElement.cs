using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterElement : Element
{
    [SerializeField] Rigidbody2D waterBall;
    [SerializeField] float waterBall_ShootForce = 2000f;
    Rigidbody2D clone;
    public override void castElement(){
        skill_WaterBall();
    }


    void skill_WaterBall(){
        Vector2 tempdir = Detector.getInputDirection(transform).normalized;
        Vector3 attackPosition = new Vector3(transform.position.x+2*tempdir.x,transform.position.y+2*tempdir.y,transform.position.z);
        clone = Instantiate(waterBall, attackPosition, transform.rotation);
        Vector2 shootForce = tempdir*waterBall_ShootForce;
        clone.AddForce(shootForce);
    }
}
