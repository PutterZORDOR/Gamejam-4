using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TakeDMGScissor : MonoBehaviour
{
    public int Hp;
    public int PlusScore = 100;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
    }
    public void TakeHitScissor(int DmgToScissor)
    {
        Hp -= DmgToScissor;
        anim.SetBool("isWalking", false);
        StartCoroutine(HitEffect());
        
        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("ตาย");
        Destroy(gameObject);
        ScoreCon.instance.AddScore(PlusScore);
    }

    private IEnumerator HitEffect()
    {
        anim.SetTrigger("TakeDMG");
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        anim.SetBool("isWalking", true);
    }
}
