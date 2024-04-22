using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyScissors : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public bool chase = false;
    public Transform startPoint;
    public bool CanWalk;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
        {
            ReturnStartPoint();
            Flip();
        }
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime); 
    }

    private void Chase()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _ = CanWalk == true;
        }
        else
        {
            _ = CanWalk == false;
        }
    }
}
