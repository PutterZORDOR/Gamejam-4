using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseHammerControll : MonoBehaviour
{
    public EnermyHammer[] enermyArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(EnermyHammer enermy in enermyArray)
            {
                enermy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(EnermyHammer enermy in enermyArray)
            {
                enermy.chase = false;   
            }
        }
    }
}
