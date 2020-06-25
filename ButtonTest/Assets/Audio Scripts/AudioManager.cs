﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public SoundContainer[] sounds;
    internal static AudioManager instance;
    public bool gate = true;
    public bool isPlaying;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (SoundContainer c in sounds)
        {
            c.source = gameObject.AddComponent<AudioSource>();
            c.source.pitch = c.pitch;
            c.source.loop = c.loop;
            c.source.playOnAwake = c.playOnAwake;
            c.source.outputAudioMixerGroup = c.group;
        }
    }
    public void Play(string name)
    {
      
            SoundContainer soundContainer = Array.Find(sounds, sound => sound.name == name);
        var i = Random.Range(0, soundContainer.clip.Length);
        if (soundContainer.source.isPlaying == true)
        {
            Debug.Log("container"  + soundContainer.clip[i].name + "is playing");
            return;
        }
        soundContainer.source.clip = soundContainer.clip[i];
        soundContainer.source.Play();
            Debug.Log("Last sound played: " + soundContainer.clip[i].name);

    }


}


