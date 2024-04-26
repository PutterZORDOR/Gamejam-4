using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class DamgeHit2Laser : MonoBehaviour
{
    private bool db = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && db == false)
        {   
            col.gameObject.GetComponent<HealthCode>().Health -= 1;
            StartCoroutine(DbTime(2));
        }
    }

    IEnumerator DbTime(int delay)
    {
        db = true;
        yield return new WaitForSeconds(delay);
        db = false;
    }
}
