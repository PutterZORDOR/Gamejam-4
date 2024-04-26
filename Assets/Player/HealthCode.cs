using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class HealthCode : MonoBehaviour
{
   public int Health = 5;
   private int OldHealth;
   public GameObject GameOverScene;
   public GameObject player;
   public Color whengethit;
   [SerializeField] private bool invissible = false;
    private bool isDead = false;
    public Image[] Heart;
    public Sprite fullHeart;
    public Sprite empthyHeart;
    public AnimatorOverrideController Normal;
    public AnimatorOverrideController Medium;
    public AnimatorOverrideController Low;

    void Start()
   {
      OldHealth = Health;
   }
   void Update ()
   {
        foreach(Image img in Heart)
        {
            img.sprite = empthyHeart;
        }
        for(int i = 0; i < Health; i++)
        {
            Heart[i].sprite = fullHeart;
        }
      if (Health <= 0)
      {  
         gameObject.GetComponent<Movment>().enabled = false;
         gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
         isDead = true;
         GameOverScene.SetActive(true);
      }
      
      if ((Health != OldHealth) && (invissible == false))
      {
         OldHealth = Health;
         StartCoroutine(HitEffect());
         HitSound();
      }


      ChangeDetailCharacter();
   }



   void ChangeDetailCharacter ()
   {
      if (Health > 4)
      {
         player.GetComponent<Animator>().runtimeAnimatorController = Normal as AnimatorOverrideController;
      }
      if (Health <= 3)
      {
         player.GetComponent<Animator>().runtimeAnimatorController = Medium as AnimatorOverrideController;
      }
      if (Health <= 1)
      {
         player.GetComponent<Animator>().runtimeAnimatorController = Low as AnimatorOverrideController;
      }
   }

   void HitSound()
   {
        SoundManager.instance.playerch1.PlayOneShot(SoundManager.instance.playerTakeHit);
   }

   IEnumerator HitEffect ()
   {
        invissible = true;
      player.GetComponent<SpriteRenderer>().color = whengethit;
      yield return new WaitForSeconds(.1f);
      player.GetComponent<SpriteRenderer>().color = Color.white;
      yield return new WaitForSeconds(.1f);
      player.GetComponent<SpriteRenderer>().color = whengethit;
      yield return new WaitForSeconds(.1f);
       player.GetComponent<SpriteRenderer>().color = Color.white;
      yield return new WaitForSeconds(.1f);
        invissible =false;

   }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
