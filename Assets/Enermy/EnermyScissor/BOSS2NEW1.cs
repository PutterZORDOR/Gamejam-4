using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BOSS2NEW1 : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;

    public GameObject ways;
    public Transform[] waypoint;
    int pointIndex;
    int pointCount;
    int direction = 1;
    private bool canHit = true;
    private void Awake()
    {
        waypoint = new Transform[ways.transform.childCount];
        for(int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            waypoint[i] = ways.transform.GetChild(i).gameObject.transform;
        }

    }

    private void Start()
    {
        pointCount = waypoint.Length;
        pointIndex = 1;
        targetPos = waypoint[pointIndex].transform.position;
    }


    private void Update()
    {

        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if(transform.position == targetPos)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        if(pointIndex == pointCount-1) 
        {
            direction = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if(pointIndex == 0 )
        {
            direction = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        pointIndex += direction;
        targetPos = waypoint[pointIndex].transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canHit == true)
        {
            HealthCode playerHP = other.gameObject.GetComponent<HealthCode>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(1);
                canHit = false;
                StartCoroutine(Delayhit(2));
            }
        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canHit == true)
        {
            HealthCode playerHP = other.gameObject.GetComponent<HealthCode>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(1);
                canHit = false;
                StartCoroutine(Delayhit(2));
            }
        }


    }
    private IEnumerator Delayhit(int delay)
    {
        yield return new WaitForSeconds(delay);
        canHit = true;

    }
}
