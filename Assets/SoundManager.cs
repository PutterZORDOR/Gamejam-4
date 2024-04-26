using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip playerTakeHit;
    public AudioClip playerSword;
    public AudioClip playerShoot;
    public AudioClip playerThrow;
    public AudioClip jump;

    public AudioClip hurtenermy;

    public AudioSource music;
    public AudioSource SFX;

    public AudioClip BGM;
    
    public static SoundManager instance { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        
    }
    private void Start()
    {
        music.clip = BGM;
        music.Play();
    }
}
