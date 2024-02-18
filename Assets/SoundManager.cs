using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singelton<SoundManager>
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private AudioSource vfxSource;
    [SerializeField] private AudioSource _backgroundMusicSource;

    [SerializeField]public AudioClip[] backgroundAudioClips;
    [SerializeField]public AudioClip[] vfxAudioClips;

    private void Start()
    {
        PrintSound(backgroundAudioClips[0]);    
    }

    public void PrintSound(AudioClip background)
    {
        _backgroundMusicSource.Stop();
        _backgroundMusicSource.loop = true;
        _backgroundMusicSource.clip = background;
        _backgroundMusicSource.Play();
    }

    public void PrintVFX(AudioClip vfx)
    {
        vfxSource.PlayOneShot(vfx);
    }
}