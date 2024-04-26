using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauses : MonoBehaviour
{
   public static bool  GameisPause =  false;
    public GameObject pauseMenuUI;
    public GameObject VolumeMenu;
    public GameObject Back;
    public GameObject SFX;
    private bool canswitch = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canswitch == true)
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

    public void SettingButton()
    {
        SFX.SetActive(true);
        VolumeMenu.SetActive(true);
        Back.SetActive(true);
        pauseMenuUI.SetActive(false);
        canswitch = false;

    }

    public void BackMenu()
    {
        SFX.SetActive(false );
        Back.SetActive(false);
        VolumeMenu.SetActive(false);
        pauseMenuUI.SetActive(true );
        canswitch = true;
    }
}
