﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmgPaper : MonoBehaviour
{
    public int Hp = 40;
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

    
}
