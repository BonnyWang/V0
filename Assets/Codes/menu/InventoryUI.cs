using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsparent;
    Backpack backPack0;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        backPack0 = Backpack.backPack0;
        backPack0.onItemChangedCallback += UpdateUI;
        slots = itemsparent.GetComponentsInChildren<InventorySlot>();

    }

    // Update is called once per frame
    void UpdateUI()
    {
        //Debug.Log(backPack0.itemNum);
        Debug.Log("update relic");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < backPack0.itemNum)
            {
                //Debug.Log("ha"+i);
                slots[i].Additem(backPack0.items[i]);

            }
            else
            {
                slots[i].Noitem();
            }
        }
        
    }
}
