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
            Boss.GetComponent<Boss1>().target = other.gameObject;
        }
    }
}
