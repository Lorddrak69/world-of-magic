using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipTake;
    public AudioClip clipDeal;
    public AudioClip clipGrabSword;
    public AudioClip clipCastFireSpell;
    public float volume=0.5f;
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
