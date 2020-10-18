using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    itemstat item;
    public void Additem( itemstat newitem)
    {
        item = newitem;
        icon.sprite = newitem.icon;
        icon.enabled = true;
    }

    public void Noitem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
