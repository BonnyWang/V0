using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public static Backpack backPack0;
    [SerializeField] int itemNum;
    [SerializeField] public itemstat[] items;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    private void Awake()
    {
        if(backPack0 != null)
        {
            Debug.Log("more than one instance");
            return;
        }
        backPack0 = this;
    }
    void Start()
    {
        // backPack0 = this;
        items  = new itemstat[100];
        itemNum = 0;
    }


    public void addObject(itemstat a){
        items[itemNum] = a;
        itemNum++;
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();

        }
    }
}
