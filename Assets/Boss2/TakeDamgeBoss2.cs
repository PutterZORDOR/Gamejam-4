using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamgeBoss2 : MonoBehaviour
{
    public int Hp = 500;
    public int PlusScore = 500;
    private ScoreCon scoreControl;

    private void Start()
    {
        scoreControl = GameObject.Find("KCO").GetComponent<ScoreCon>();
    }
    public void TakeHitBoss2(int DmgToBoss2)
    {
        Hp -= DmgToBoss2;
        StartCoroutine(HitEffect());

        if (Hp <= 0)
        {
            Die();
            scoreControl.AddPointEnermy();
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
        
        SoundManager.instance.SFX.PlayOneShot(SoundManager.instance.hurtenermy);
        Debug.Log("ตาย");
        Destroy(gameObject);

    }
}
