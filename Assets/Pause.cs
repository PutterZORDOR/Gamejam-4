using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePannel;
 
    void Update()
    {
        
    }

    public void Pauses()
    {
        PausePannel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PausePannel.SetActive(false);
        Time.timeScale = 1;
    }
}
