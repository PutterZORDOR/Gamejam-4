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
   public GameObject player;
   public Color whengethit;

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
         StartCoroutine(HitEffect());
      }
   }

   IEnumerator HitEffect ()
   {
      player.GetComponent<SpriteRenderer>().color = whengethit;
      yield return new WaitForSeconds(.1f);
      player.GetComponent<SpriteRenderer>().color = Color.white;
      yield return new WaitForSeconds(.1f);
      player.GetComponent<SpriteRenderer>().color = whengethit;
      yield return new WaitForSeconds(.1f);
       player.GetComponent<SpriteRenderer>().color = Color.white;
   }
}
