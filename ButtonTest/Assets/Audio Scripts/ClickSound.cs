using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip sound;

    private Button Button { get { return GetComponent<Button>(); } }
    private AudioSource Source { get { return GetComponent<AudioSource>(); } }


    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        Source.clip = sound;
        Source.playOnAwake = false;

        Button.onClick.AddListener(() => PlaySound());
    }
    void PlaySound()
    {
        Source.PlayOneShot(sound);
    }
}