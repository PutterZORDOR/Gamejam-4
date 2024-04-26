using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauses : MonoBehaviour
{
   public static bool  GameisPause =  false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameisPause)
            {
                Resume();
            }else
            {
                Pausess();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPause = false;
    }

    void Pausess()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
    }

    public void ResumeButton()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPause = false;
    }

    void SettingButton()
    {

    }
}
