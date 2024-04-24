using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerDetect : MonoBehaviour
{
    public GameObject Boss;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {   
            if (Boss.GetComponent<Boss1>())
            {
                Boss.GetComponent<Boss1>().target = other.gameObject;
            }
            if (Boss.GetComponent<Boss2Ai>())
            {
                Boss.GetComponent<Boss2Ai>().target = other.gameObject;
            }
        }
    }
}
