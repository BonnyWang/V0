using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attributes: MonoBehaviour
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
