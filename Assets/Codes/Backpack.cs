using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    // public static Backpack backPack0;
    [SerializeField] static string[] items;
    static int itemNum;
    void Start()
    {
        // backPack0 = this;
        items  = new string[100];
        itemNum = 0;
    }


    public static void addObject(string name){
        items[itemNum] = name;
        itemNum++;
    }
}
