using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmgPaper : MonoBehaviour
{
    public int PlusScore = 100;
    private ScoreCon scoreController;
    public int Hp = 40;

    private void Awake()
    {
        scoreController = FindAnyObjectByType<ScoreCon>();
    }
    public void TakeHitPaper(int DmgToPaper)
    {
        Hp -= DmgToPaper;

        if (Hp <= 0) 
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("ตาย");
        Destroy(gameObject);
    }

    public void AllocateScore()
    {
        scoreController.AddScore(PlusScore);
    }

}
