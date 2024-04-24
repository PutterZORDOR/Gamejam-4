using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    //idel Stage
    [Header("Idel")]
    [SerializeField] float idelMoveSpeed;
    [SerializeField] Vector2 idelMoveDirection;
    //For Attack Up N down Stage
    [Header("AttackUpNDown")]
    [SerializeField] float attackMoveSpeed;
    [SerializeField] Vector2 attackMoveDirection;
    //For Attack Player Stage
    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    [SerializeField] Transform player;
    private Vector2 playerPosition;
    //Other
    [Header("Other")]
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private bool goingUp = true;
    private bool FacingLeft = true;
    private Rigidbody2D enermyRB;


    private void Start()
    {
        idelMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        enermyRB = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);
        //IdelState();
        //AttackUpDown();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AttackPlayer();
        }
        

    }

    void Filp()
    {
        FacingLeft = !FacingLeft;
        idelMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void IdelState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }
        enermyRB.velocity = idelMoveSpeed * idelMoveDirection;

        if (isTouchingWall)
        {
            if (FacingLeft)
            {
                Filp();
            }
            else if(!FacingLeft) 
                {
                Filp();

                }
        }
    }

    void AttackUpDown()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }
        enermyRB.velocity = attackMoveSpeed * attackMoveDirection;

        if (isTouchingWall)
        {
            if (FacingLeft)
            {
                Filp();
            }
            else if (!FacingLeft)
            {
                Filp();

            }
        }
    }

    void AttackPlayer()
    {
        playerPosition = player.position - transform.position;


        enermyRB.velocity = playerPosition * attackPlayerSpeed;
    }

    void FilpTowardPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if(playerDirection >0 && FacingLeft)
        {
            Filp();
        }else if (playerDirection<0 && !FacingLeft)
        {
            Filp();
        }
    }

    void ChangeDirection()
    {
        goingUp = !goingUp;
        idelMoveDirection.y *= -1;
        attackMoveDirection.y *= -1 ;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);
    }
}
