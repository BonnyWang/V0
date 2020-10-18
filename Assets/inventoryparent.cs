using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class inventoryparent : MonoBehaviour
{
    public GameObject description;
    bool Istimer = false;
    float second = 0;
    public void OnTabEnter(InventorySlot slot)
    {
        if (slot.item != null)
        {
            description.SetActive(true);
            description.transform.position = slot.GetComponent<Transform>().position + new Vector3(145, 0, 0);
            description.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = slot.item.itemname;
            description.transform.Find("iteminfo").GetComponent<TextMeshProUGUI>().text = slot.item.info;

        }
    }

    public void onTabExit(InventorySlot slot)
    {
        //Istimer = true;
        description.SetActive(false);
    }



    private void Update()
    {
        
        if (Istimer)
        {
            Debug.Log(second);
            second += Time.deltaTime;
        }
        if (second > 1)
        {
            Debug.Log("intimer");
            Istimer = false;
            second = 0;
            description.SetActive(false);
        }
    }
}
