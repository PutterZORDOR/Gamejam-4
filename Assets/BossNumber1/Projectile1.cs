using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    public float speed = 20f;
     public Rigidbody2D rb;

    void Start ()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(stepBack());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {   
            col.gameObject.GetComponent<HealthCode>().Health -= 1;
            Destroy(gameObject);
        }
    }

    IEnumerator stepBack ()
    {
        yield return new WaitForSeconds (2.5f);
        rb.velocity = transform.right * -speed;
        yield return new WaitForSeconds (2.5f);
        Destroy(gameObject);
    }

}
