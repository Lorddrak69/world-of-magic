using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionMusic : MonoBehaviour
{
    public AudioSource audioSourceInside;
    public AudioSource audioSourceOutside;
    public bool isMutedInside;
    public bool isMutedOutside;

    void Start()
    {
        isMutedInside = true;
        isMutedOutside = false;
        audioSourceInside.Stop();
        audioSourceOutside.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSourceInside.Play();
            audioSourceOutside.Stop();
            isMutedInside = false;
            isMutedOutside = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSourceInside.Stop();
            audioSourceOutside.Play();
            isMutedInside = true;
            isMutedOutside = false;
        }
    }
}
