using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public itemstat item;
    public inventoryparent inventoryparent;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hover");
        inventoryparent.OnTabEnter(this);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        inventoryparent.onTabExit(this);
    }
}
