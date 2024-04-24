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
        }

        if(pointIndex == 0 )
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = waypoint[pointIndex].transform.position;
    }
}
