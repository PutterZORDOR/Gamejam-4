using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource playerch1;
    public AudioClip playerTakeHit;
    public AudioClip playerSword;
    public AudioClip playerShoot;
    public AudioClip playerThrow;
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
}
