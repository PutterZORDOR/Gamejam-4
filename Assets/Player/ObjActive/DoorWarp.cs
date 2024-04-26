using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWarp : MonoBehaviour
{
    public GameObject Camera;
    public Transform DoorA;
    public Transform DoorB;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {   
            GameObject player = col.gameObject;
            StartCoroutine(Warp(player));
        }
    }

    IEnumerator Warp(GameObject player)
    {
        yield return new WaitForSeconds(.1f);

        Camera.GetComponent<CameraMove>().enabled = false;
        player.GetComponent<Movment>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(1f);
        player.transform.position = DoorB.transform.position;
        Camera.transform.position = player.transform.position;
        yield return new WaitForSeconds(.1f);

        player.GetComponent<Movment>().enabled = true;
        Camera.GetComponent<CameraMove>().enabled = true;
    }
}
