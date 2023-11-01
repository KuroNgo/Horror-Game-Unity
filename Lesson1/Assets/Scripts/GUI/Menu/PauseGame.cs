using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;

    void Update()
    {
        // Kiểm tra nút F hoặc Esc được nhấn
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Screen.lockCursor = false;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Screen.lockCursor = true;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}