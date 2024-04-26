using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmgPaper : MonoBehaviour
{
    public int Hp = 100;
    private bool canHit = true;
    public int PlusScore = 100;
    public Transform other;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walk", true);
    }
    public void TakeHitPaper(int DmgToPaper)
    {
        Hp -= DmgToPaper;
        anim.SetBool("walk", false);
        StartCoroutine(HitEffect());

        if (Hp <= 0) 
        {
            Die();
        }
    }
    private void Update()
    {
        float dist = Vector2.Distance(other.position, transform.position);
        if(dist > 13)
        {
            anim.SetBool("walk",false);
        }
        if (dist < 13)
        {
            anim.SetBool("walk", true);
        }
    }

    private IEnumerator HitEffect()
    {
        anim.SetTrigger("takedmg");
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        anim.SetBool("walk", true);
    }

    public void Die()
    {
        Debug.Log("ตาย");
        SoundManager.instance.SFX.PlayOneShot(SoundManager.instance.hurtenermy);
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
                anim.SetBool("walk",false);
                anim.SetTrigger("attack");
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
                anim.SetTrigger("attack");
                anim.SetBool("walk", false);
                canHit = false;
                StartCoroutine(Delayhit(2));
            }
        }


    }
    private IEnumerator Delayhit(int delay)
    {
        
        yield return new WaitForSeconds(delay);
        canHit = true;
        anim.SetBool("walk", true);

    }
}
