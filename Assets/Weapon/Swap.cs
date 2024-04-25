using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;


    private void Start()
    {
        Slot1.SetActive(true);
        Slot2.SetActive(false);
        Slot3.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Equip1();
        }

        if (Input.GetKeyDown("2"))
        {
            Equip2();
        }

        if (Input.GetKeyDown("3"))
        {
            Equip3();
        }
    }

    private void Equip3()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(true);
    }

    private void Equip2()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(true);
        Slot3.SetActive(false);
    }

    private void Equip1()
    {
        Slot1.SetActive(true);
        Slot2.SetActive(false);
        Slot3.SetActive(false);
    }
}