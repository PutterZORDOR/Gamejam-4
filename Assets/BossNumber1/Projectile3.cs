using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3 : MonoBehaviour
{
     public float speed = 5f;
     public Rigidbody2D rb;

    void Start ()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {   
            col.gameObject.GetComponent<HealthCode>().Health -= 1;
            Destroy(gameObject);
        }
    }

}
