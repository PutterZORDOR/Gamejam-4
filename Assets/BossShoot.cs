using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Transform bulletPos2;

    public float timer;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        float distance = Vector2.Distance(transform.position,player.transform.position);

        
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                Shoot();
            }
        
           
        
    }

    private void Shoot()
    {
        Instantiate(bullet,bulletPos.position, Quaternion.identity);
        Instantiate(bullet, bulletPos2.position, Quaternion.identity);
    }
}
