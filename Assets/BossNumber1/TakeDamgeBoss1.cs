﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamgeBoss1 : MonoBehaviour
{
    public int Hp = 500;
    public int PlusScore = 500;
    private ScoreCon scoreControl;


    private void Start()
    {
        scoreControl = GameObject.Find("KCO").GetComponent<ScoreCon>();
    }
    public void TakeHitBoss1(int DmgToBoss1)
    {
        Hp -= DmgToBoss1;
        StartCoroutine(HitEffect());

        if (Hp <= 0)
        {
            Die();
        }
    }

    private IEnumerator HitEffect()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Die()
    {
        
        Debug.Log("ตาย");
        Destroy(gameObject);
        scoreControl.AddPointBoss();
    }
}
