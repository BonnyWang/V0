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
    public static bool onRope;
    
    //Reference variable
    public static float timeAttacked;

    //Interact
    public static GameObject collidewith;

    // 
    public Player_Interaction player_Interaction;

    //Base

    //six attribute(emo/con/ext/ope/hon/agr)
    public static int emo=1;
    public static int con=2;
    public static int ext=3;
    public static int ope=4;
    public static int hon=5;
    public static int agr=6;

    public void changeFace(int a,int b)
    {
        if (a == 1)
        {
            emo += b;
        }
        if (a == 2)
        {
            con += b;
        }
        if (a == 3)
        {
            ext += b;
        }
        if (a == 4)
        {
            ope += b;
        }
        if (a == 5)
        {
            hon += b;
        }
        if (a == 6)
        {
            agr += b;
        }
    }
    private void Start() {
        initialization();
    }

    private void initialization(){
        health = 50;
        attackMode = 0;
        wearMask = false;
        underAttack = false;
        onRope = false;

        player_Interaction = GetComponent<Player_Interaction>();
    }
}
