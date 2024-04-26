using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagShowType : MonoBehaviour
{   
    public GameObject Character;
    public GameObject PaperIcon; 
    public GameObject ScissorsIcon;
    public GameObject HammerIcon;
    void Update()
    {
        if (Character.tag == "PaperEnermy")
        {
            PaperIcon.gameObject.SetActive(true);

            ScissorsIcon.gameObject.SetActive(false);
            HammerIcon.gameObject.SetActive(false);
        }
         if (Character.tag == "ScissorsEnermy")
        {
            PaperIcon.gameObject.SetActive(false);
            ScissorsIcon.gameObject.SetActive(true);
            HammerIcon.gameObject.SetActive(false);
        }
         if (Character.tag == "HammerEnermy")
        {
            PaperIcon.gameObject.SetActive(false);
            ScissorsIcon.gameObject.SetActive(false);
            HammerIcon.gameObject.SetActive(true);
        }
    }
}
