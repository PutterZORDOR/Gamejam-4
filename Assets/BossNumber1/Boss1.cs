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
    public GameObject ProjectileOBJ3;

    public GameObject ProjectileMain3;

    private bool dbxproj = false;

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
        int ran = Random.Range(1, 5);
        Debug.Log(ran);
        if (ran == 1)
        {
            Instantiate(ProjectileOBJ, firepointRight.position, firepointRight.rotation);
            gameObject.tag = "PaperEnermy";
        }
        if (ran == 2)
        {
            Instantiate(ProjectileOBJ, firepointLeft.position, firepointLeft.rotation);
        }
        if (ran == 3)
        {
            Instantiate(ProjectileOBJ2, firepointRightX.position, firepointRightX.rotation);
            Instantiate(ProjectileOBJ2, firepointLeftX.position, firepointLeftX.rotation);
            gameObject.tag = "ScissorsEnermy";
        }
        if (ran == 4)
        {
            GameObject _MAINPOS = Instantiate(ProjectileMain3, gameObject.transform.position, gameObject.transform.rotation);

            GameObject Pos1 = _MAINPOS.transform.GetChild(0).gameObject;
            GameObject Pos2 = _MAINPOS.transform.GetChild(1).gameObject;
            GameObject Pos3 = _MAINPOS.transform.GetChild(2).gameObject;

            GameObject _PJ1 = Instantiate(ProjectileOBJ3, Pos1.transform.position, Pos1.transform.rotation);
            _PJ1.transform.parent = _MAINPOS.transform;
            GameObject _PJ2 = Instantiate(ProjectileOBJ3, Pos2.transform.position, Pos2.transform.rotation);
             _PJ2.transform.parent = _MAINPOS.transform;
            GameObject _PJ3 = Instantiate(ProjectileOBJ3, Pos3.transform.position, Pos3.transform.rotation);
             _PJ3.transform.parent = _MAINPOS.transform;
            gameObject.tag = "HammerEnermy";
        }

        yield return new WaitForSeconds(1f);
        dbxproj = false;
    }
}
