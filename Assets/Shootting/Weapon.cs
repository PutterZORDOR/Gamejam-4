using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackRate = 2f;
    float nextAttack = 0f;

    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                
                nextAttack = Time.time + 1f / attackRate;

            }
        }
    }
    void Shoot()
    {
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }

    
}
