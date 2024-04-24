using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector2 _velocity;

    public BoxCollider2D bc2D;

    // Use this for initialization
    void Start()
    {
        _velocity = transform.right * speed;
        rb.velocity = _velocity;
        StartCoroutine(Desself());
        //_rb.AddForce(_velocity, ForceMode.VelocityChange);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("Environment"))
        {
            ReflectProjectile(rb, collision.contacts[0].normal);
        }
    }

    private void ReflectProjectile(Rigidbody2D rb, Vector2 reflectVector)
    {    
        _velocity = Vector2.Reflect(_velocity, reflectVector).normalized;
        rb.velocity = _velocity * speed;
    }

    IEnumerator Desself ()
    {
        yield return new WaitForSeconds (15f);
        Destroy(gameObject);
    }
}
