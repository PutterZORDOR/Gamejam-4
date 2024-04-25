using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmgPaper : MonoBehaviour
{
    public int Hp = 100;
    private bool canHit = true;
    public int PlusScore = 100;

    public void TakeHitPaper(int DmgToPaper)
    {
        Hp -= DmgToPaper;
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



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canHit == true)
        {
            HealthCode playerHP = other.gameObject.GetComponent<HealthCode>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(1);
                canHit = false;
                StartCoroutine(Delayhit(2));
            }
        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canHit == true)
        {
            HealthCode playerHP = other.gameObject.GetComponent<HealthCode>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(1);
                canHit = false;
                StartCoroutine(Delayhit(2));
            }
        }


    }
    private IEnumerator Delayhit(int delay)
    {
        yield return new WaitForSeconds(delay);
        canHit = true;

    }
}
