using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject Doorlock;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {   
            Doorlock.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
