using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    int totalWeapon = 1;
    public int currentWeaponIndex;

    public GameObject[] weapon;
    public GameObject weaponHolder;
    public GameObject currentWeapon;


    private void Start()
    {
        totalWeapon = weaponHolder.transform.childCount;
        weapon = new GameObject[totalWeapon];

        for (int i = 0; i < totalWeapon; i++)
        {
            weapon[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapon[i].SetActive(false);
        }

        weapon[0].SetActive(true);

        currentWeapon = weapon[0];
        currentWeaponIndex = 0;
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            if(currentWeaponIndex < totalWeapon-1)
            {
                weapon[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                weapon[currentWeaponIndex].SetActive(true);
                currentWeapon = weapon[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (currentWeaponIndex > 0)
            {
                weapon[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                weapon[currentWeaponIndex].SetActive(true); 
            }
        }
        
    }
}
