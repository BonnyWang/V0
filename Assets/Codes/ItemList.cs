using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public Player_Attributes PA;
    public void itemeffect(string a)
    {
        if (a == "heart")
        {
            PA.changeFace(1, 3);
            PA.changeFace(2, 10);
        }
        if (a == "heart2")
        {
            PA.changeFace(4, -10);
        }
    }
}
