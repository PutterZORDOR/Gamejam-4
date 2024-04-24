using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RPS : MonoBehaviour
{
    public int RadNum;
    public bool db = false;


    private void Start()
    {

    }
    private void Update()
    {
        if (db != true)
        {
            StartCoroutine(DelayRan());
        }




    }

    private IEnumerator DelayRan()
    {
        db = true;
        yield return new WaitForSeconds(10);
        RadNum = Random.Range(0, 4);
        if(RadNum == 1)
        {
            gameObject.tag = "HammerEnermy";
        }
        if (RadNum == 2)
        {
            gameObject.tag = "ScissorsEnermy";
        }
        if (RadNum == 3)
        {
            gameObject.tag = "PaperEnermy";
        }
        db = false;

    }
}
