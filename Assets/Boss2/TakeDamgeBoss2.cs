﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamgeBoss2 : MonoBehaviour
{
    public int Hp = 500;
    public int PlusScore = 500;

    public void TakeHitBoss2(int DmgToBoss2)
    {
        Hp -= DmgToBoss2;
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
        ScoreCon.instance.AddScore(PlusScore);
    }
}
