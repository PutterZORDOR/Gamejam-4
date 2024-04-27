using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TakeDMGScissor : MonoBehaviour
{
    public int Hp = 20;
    public int PlusScore = 100;
    private Animator anim;
    private ScoreCon scoreControl;
    public GameObject fire;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
    }

    private void Start()
    {
        scoreControl = GameObject.Find("KCO").GetComponent<ScoreCon>();
    }
    public void TakeHitScissor(int DmgToScissor)
    {
        Hp -= DmgToScissor;
        anim.SetBool("isWalking", false);
        StartCoroutine(HitEffect());
        
        if (Hp <= 0)
        {
            SoundManager.instance.SFX.PlayOneShot(SoundManager.instance.hurtenermy);
            Die();
            scoreControl.AddPointEnermy();
        }
    }

    public void Die()
    {
        Instantiate(fire, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
