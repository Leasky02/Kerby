﻿using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    public AudioSource AudioSrc;

    public float AudioVolume = 0.5f;

    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        AudioSrc.volume = AudioVolume / 2;
    }

    public void SetVolume(float vol)
    {
        AudioVolume = vol;
    }
}