using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class bulletKang : MonoBehaviour
{
    public int Dmg = 20;
    public Rigidbody2D rb;
    public float speed = 20f;
    public float bulletLifetime = 2.5f;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        StartCoroutine(DestroyBulletAfterTime(bulletLifetime));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScissorsEnermy"))
        {
            
            Destroy(gameObject);
            other.gameObject.GetComponent<TakeDmgPaper>().TakeHitPaper(Dmg);
        }

        if (other.gameObject.CompareTag("Environment"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<TakeDmgPaper>().TakeHitPaper(Dmg);
        }

        
    }

    private IEnumerator DestroyBulletAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
