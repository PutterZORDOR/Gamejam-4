using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Spining : MonoBehaviour
{
    public Vector3 Rotate;
    public float Speed;
    void Start ()
    {
        StartCoroutine(DEsSelf());
    }
    void Update()
    {
        this.transform.Rotate(Rotate * Speed * Time.deltaTime);
    }

    IEnumerator DEsSelf()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject, 5);
    }
}
