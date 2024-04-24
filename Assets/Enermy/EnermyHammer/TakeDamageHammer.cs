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

        if (Hp <= 0)
        {
            Die();
        }
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
