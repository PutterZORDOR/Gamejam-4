using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyHammer : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public bool chase = false;
    public Transform startPoint;
    public int DMG = 1;
    private Animator anim;
    private bool canHit = true;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (player == null)
            return;
        if (chase == true)
        {
            Chase();

        }

        else
        {

            ReturnStartPoint();
            Flip();
        }
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
        anim.SetBool("Chase", false);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Chase()
    {
        anim.SetBool("Chase", true);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canHit == true)
        {
            HealthCode playerHP = other.gameObject.GetComponent<HealthCode>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(DMG);
                canHit = false;
                StartCoroutine(Delayhit(2));
                
            }
        }

        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canHit == true)
        {
            HealthCode playerHP = other.gameObject.GetComponent<HealthCode>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(1);
                canHit = false;
                StartCoroutine(Delayhit(2));
            }
        }


    }
    private IEnumerator Delayhit(int delay)
    {
        yield return new WaitForSeconds(delay);
        canHit = true;

    }
}
