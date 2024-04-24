using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Ai : MonoBehaviour
{
    public GameObject target;
    public Vector3 DefaultPos;
    public GameObject enemy;
    private bool db = false;
    private bool Enemyadded = false;
    private float startTime;

    void Start()
    {
        DefaultPos = transform.position;
    }
    void Update()
    {
        if (target != null)
        {
            if (db != true)
            {
                startTime = Time.time;
                StartCoroutine(AttackRan());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {   
            col.gameObject.GetComponent<HealthCode>().Health -= 1;
        }
    }

    IEnumerator AttackRan ()
    {
        db = true;

        int ranskill = Random.Range(1,3);

        if (ranskill == 1)
        {   
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
            yield return new WaitForSeconds (2f);
            gameObject.transform.position = target.transform.position + new Vector3(-10,0,0);
            yield return new WaitForSeconds (.1f);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * 20;
            yield return new WaitForSeconds (3f);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = DefaultPos;
            yield return new WaitForSeconds (5f);
        }
        if (ranskill == 2 && Enemyadded != true)
        {   
            Enemyadded = true;
            Instantiate(enemy, gameObject.transform.position + new Vector3(0,-5,0), gameObject.transform.rotation);
            yield return new WaitForSeconds (1f);
        }
        db = false;
    }

}
