using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSelf : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(Bomb(1));
    }

    private IEnumerator Bomb(int v)
    {
        yield return new WaitForSeconds(v);
        Destroy(gameObject);
    }
}
