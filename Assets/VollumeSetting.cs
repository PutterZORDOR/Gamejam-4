using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VollumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider museslide;
    [SerializeField] private AudioMixer SFXmixer;
    [SerializeField] private Slider SFXslider;

    private void Start()
    {
        SetMusicVolume();
        SetSGXVolume();
    }

    public void SetSGXVolume()
    {
        float sfxvolume = SFXslider.value;
        SFXmixer.SetFloat("KKK", Mathf.Log10(sfxvolume) * 20);
    }

    public void SetMusicVolume()
    {
        float volume = museslide.value;
        audioMixer.SetFloat("DDD",Mathf.Log10(volume)*20);
    }
}
