using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{
    public void play()
    {
        Debug.Log("gogogo!");
    }

    public void setting()
    {
        Debug.Log("setting");
    }

    public void quit()
    {
        Debug.Log("bye~");
        Application.Quit();
    }
}
