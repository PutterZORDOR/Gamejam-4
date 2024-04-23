using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMove : MonoBehaviour
{
    public Transform Platform;
    public Transform Startpoint;
    public Transform EndPoint;
    public int Speed;
    Vector2 targetPos;

    void Start()
    {
        targetPos = Startpoint.position;
    }

    void Update()
    {
        if (Vector2.Distance(Platform.position, Startpoint.position) < .1f) targetPos = EndPoint.position;

        if (Vector2.Distance(Platform.position, EndPoint.position) < .1f) targetPos = Startpoint.position;
    
        Platform.position = Vector2.MoveTowards(Platform.position, targetPos, Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.gameObject.name == "Player")
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

            col.transform.SetParent(this.transform);
        }
    }

        void OnTriggerExit2D(Collider2D col)
    {   
        if (col.gameObject.name == "Player")
        {
            col.transform.SetParent(null);
        }
    }
}
