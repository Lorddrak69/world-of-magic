using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats_Enemy : MonoBehaviour
{
    [Header("Base")]
    public float maxhealth = 0.0f;
    public float currenthealth = 0.0f;
    public float healthregen = 0.0f;
    public float damage = 0.0f;

    [Header("Extras")]
    public float armor = 0.0f;
    public float magicresist = 0.0f;

    [Header("Animator")]
    public float temp_currenthealth;

    void Start()
    {
        temp_currenthealth = currenthealth;  
    }

    void Update()
    {
        if (temp_currenthealth > currenthealth)
        {
            temp_currenthealth = currenthealth;
        }

        if (currenthealth <= 0)
        {
            //animator.SetBool("Die", true);
        }
    }
}
