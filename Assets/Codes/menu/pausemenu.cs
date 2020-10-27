using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public audioManager AM;
    public static bool IsPaused = false;
    [SerializeField] public GameObject PauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (IsPaused)
            {
                ResumeGame();
                AM.StopSound("pausemenu");
            }
            else
            {
                PauseGame();
                AM.PlaySound("pausemenu");
            }
        }
    }


    void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Debug.Log("go to main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("bye~");
        Application.Quit();
    }


}
