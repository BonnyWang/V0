using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    [SerializeField] Backpack mbackpack;
    public ItemList IL;
    public string namee;
    public Player_Attributes PA;
    private void Start()
    {
        PA = GetComponent<Player_Attributes>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Substring(0,4) == "item"){
            Destroy(other.gameObject);
            itemstat thisitem = other.gameObject.GetComponent<Itemlink>().item;
            itemeffect(thisitem);
            //namee = other.gameObject.name;
            //Debug.Log(namee);
            //IL.itemeffect(namee);
            mbackpack.addObject(thisitem);
            Debug.Log("itemCollected");
        }
    }


    public void itemeffect(itemstat a)
    {   

        PA.changeFace(1, a.emo);
        PA.changeFace(2, a.con);
        PA.changeFace(3, a.ext);
        PA.changeFace(4, a.ope);
        PA.changeFace(5, a.hon);
        PA.changeFace(6, a.agr);

    }
}
