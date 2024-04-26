using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enermyLayer;
    public int attackDMG = 40;
    public float attackRate = 2f;
    float nextAttack = 0f;
    private void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnermy =  Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enermyLayer);
        SoundManager.instance.SFX.PlayOneShot(SoundManager.instance.playerSword);

        foreach (Collider2D enermy in hitEnermy)
        {
            if(enermy.gameObject.name == "Gasu")
               enermy.GetComponent<TakeDamageHammer>().TakeHitHammer(attackDMG);

            if (enermy.gameObject.name == "Boss1")
                enermy.GetComponent<TakeDamgeBoss1>().TakeHitBoss1(attackDMG);

            if (enermy.gameObject.name == "Boss2")
                enermy.GetComponent<TakeDamgeBoss2>().TakeHitBoss2(attackDMG);

            if (enermy.gameObject.name == "Boss3")
                enermy.GetComponent<TakeDamgeBoss3>().TakeHitBoss3(attackDMG);
        }
    }

    private void OnDrawGizmos()
    {
        if(attackPoint == null)
        { return; }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
