using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    // public static Backpack backPack0;
    [SerializeField] int itemNum;
    [SerializeField] string[] items;

    void Start()
    {
        // backPack0 = this;
        items  = new string[100];
        itemNum = 0;
    }


    public void addObject(string name){
        items[itemNum] = name;
        itemNum++;
    }
}
