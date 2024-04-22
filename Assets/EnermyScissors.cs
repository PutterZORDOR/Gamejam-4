using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyScissors : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    bool isFacingRigibody;
    Rigidbody2D rb;
    BoxCollider2D myBoxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsFacingRigibody())
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRigibody()
    {
        return transform.localScale.x > Mathf.Epsilon;

    }
      
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
}
