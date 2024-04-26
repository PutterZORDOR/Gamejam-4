using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWarpScene : MonoBehaviour
{
    public int NumScene;
    public GameObject Camera;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {   
            SceneManager.LoadScene(NumScene);
        }
    }
}
