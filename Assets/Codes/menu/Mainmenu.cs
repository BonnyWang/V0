using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void play()
    {
        Debug.Log("gogogo!");
        SceneManager.LoadScene("main");
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
