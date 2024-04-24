using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HealthCode : MonoBehaviour
{
   public int Health = 5;
   private int OldHealth;
   public GameObject GameOverScene;
   public Transform player;

   void Start()
   {
      OldHealth = Health;
   }
   void Update ()
   {
      if (Health <= 0)
      {  
         gameObject.GetComponent<Movment>().enabled = false;
         gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
         GameOverScene.SetActive(true);
      }
      
      if (Health != OldHealth)
      {
         
         OldHealth = Health;
      }
   }
}
