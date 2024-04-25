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
<<<<<<< Updated upstream
    public int DMG = 1;
=======
>>>>>>> Stashed changes

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

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0,0,0);
    else
            transform.rotation = Quaternion.Euler(0,180,0);
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
