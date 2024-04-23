using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageHammer : MonoBehaviour
{
    public int Hp = 40;
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
        Destroy(gameObject);
    }
}
