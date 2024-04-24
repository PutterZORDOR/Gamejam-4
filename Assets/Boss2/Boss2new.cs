using UnityEngine;

public class Boss2new : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public float speed = 5f; // Speed at which the enemy moves
    private Vector2 initialPosition; // Initial position of the enemy

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {        
       Patrol();       
    }
    void Patrol()
    {       
        transform.position = initialPosition + new Vector2(Mathf.Sin(Time.time * speed), Mathf.Cos(Time.time * speed));
    }        
}

