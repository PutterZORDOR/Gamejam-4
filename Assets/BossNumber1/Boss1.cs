using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject target;
    public Transform firepointRight;
    public Transform firepointLeft;


    public Transform firepointRightX;
    public Transform firepointLeftX;


    public GameObject ProjectileOBJ;
    public GameObject ProjectileOBJ2;

    private bool dbxproj = false;

    private GameObject oldp1;
    private GameObject oldp2;

    void Update()
    {
        if (target != null)
        {
            if (dbxproj != true)
            {
                StartCoroutine(xProjectile());
            }
        }
    }

    IEnumerator xProjectile()
    {   
        dbxproj = true;
        int ran = Random.Range(1, 4);
        Debug.Log(ran);
        if (ran == 1)
        {
            Instantiate(ProjectileOBJ, firepointRight.position, firepointRight.rotation);
        }
        if (ran == 2)
        {
            Instantiate(ProjectileOBJ, firepointLeft.position, firepointLeft.rotation);
        }
        if (ran == 3)
        {
            GameObject p1 = Instantiate(ProjectileOBJ2, firepointRightX.position, firepointRightX.rotation);
            GameObject p2 = Instantiate(ProjectileOBJ2, firepointLeftX.position, firepointLeftX.rotation);
        }

        yield return new WaitForSeconds(1f);
        dbxproj = false;
    }
}
