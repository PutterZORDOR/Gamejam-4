using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageHammer : MonoBehaviour
{
    public int Hp = 40;
    public int PlusScore = 100;
    private ScoreCon scoreController;

    private void Awake()
    {
        scoreController = FindAnyObjectByType<ScoreCon>();
    }
    public void TakeHitHammer(int DmgToHammer)
    {
        Hp -= DmgToHammer;
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
        AllocateScore();
        Destroy(gameObject);
    }

    public void AllocateScore()
    {
        scoreController.AddScore(PlusScore);
    }
}
