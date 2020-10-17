using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attributes: Attributes
{
    //Basic Properties
    public static int health;
    public static int attackMode;

    //Modes
    public static bool wearMask;
    public static bool underAttack;
    
    //Reference variable
    public static float timeAttacked;

    //Interact
    public static GameObject collidewith;

    //Base

    //six attribute(emo/con/ext/ope/hon/agr)
    public static int emo=1;
    public static int con=2;
    public static int ext=3;
    public static int ope=4;
    public static int hon=5;
    public static int agr=6;

    private void Start() {
        initialization();
    }

    private void initialization(){
        health = 50;
        attackMode = 0;
        wearMask = false;
        underAttack = false;
    }
}
