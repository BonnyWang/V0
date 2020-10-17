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

    public void subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }


    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        button.background.sprite = tabHovered;
    }

    public  void onTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void onTabSelected(TabButton button)
    {
        ResetTabs();
        button.background.sprite = tabSelected;
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            button.background.sprite = tabIdle;
        }
    }
}
