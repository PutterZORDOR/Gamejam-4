using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {   
            col.gameObject.GetComponent<HealthCode>().Health -= 1;
            Destroy(gameObject);
        }
    }
}
