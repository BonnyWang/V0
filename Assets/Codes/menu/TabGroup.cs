using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHovered;
    public Sprite tabSelected;
    public TabButton selectedTab;
    public List<GameObject> TabPages;
    public void subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
        //Debug.Log(button.name);
        if (tabButtons.Count == 6)
        {
            //Debug.Log("hello");
            onTabSelected(tabButtons[2]);
        }
    }


    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabHovered;
        }
    }

    public  void onTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void onTabSelected(TabButton button)
    {   
        
        FindObjectOfType<audioManager>().PlaySound("buttonClicked");
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabSelected;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < TabPages.Count; i++)
        {
            if (i == index)
            {
                Debug.Log("tab" + i);
                TabPages[i].SetActive(true);
            }
            else
            {
                TabPages[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if(selectedTab!=null &&button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }
}
