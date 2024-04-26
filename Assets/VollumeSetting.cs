using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VollumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider museslide;

    private void Start()
    {
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        float volume = museslide.value;
        audioMixer.SetFloat("DDD",Mathf.Log10(volume)*20);
    }
}
