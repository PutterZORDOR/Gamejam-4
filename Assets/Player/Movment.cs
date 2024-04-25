using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 30f;
    private bool IsJumping = false;
    private float JumpTime;
    public float JumpStartTime;
    public GameObject Character;
    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private TrailRenderer tr;
    

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
       // Debug.Log(IsJumping);
        Jump();
        Flip();
        
        
    }

    void Jump ()
    {
        if (IsGrounded() == true && Input.GetButtonDown("Jump"))
        {
            IsJumping = true;
            JumpTime = JumpStartTime;
            rb.velocity = Vector2.up * jumpingPower;
        }

        if (Input.GetButton("Jump") && IsJumping == true)
        {
            if (JumpTime > 0 )
            {
                rb.velocity = Vector2.up * jumpingPower;
                JumpTime = JumpTime - Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            IsJumping = false;
        }

        if (!IsGrounded() == false && IsJumping == false)
        {   
            if (rb.gravityScale < 5f)
            {
                rb.gravityScale += 2f;
            }
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void FixedUpdate()
    {   
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        //{if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        //{
        //    isFacingRight = !isFacingRight;
        //    Vector3 localScale = transform.localScale;
        //    localScale.x *= -1f;
        //    transform.localScale = localScale;
        //}

        if (!Mathf.Approximately(0, horizontal))
        Character.transform.rotation = horizontal < 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
<<<<<<< Updated upstream
    }    
    

=======
    }
>>>>>>> Stashed changes
}
