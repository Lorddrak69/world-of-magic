using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats_Player : MonoBehaviour
{
    [Header("Base")]
    public float maxhealth = 0.0f;
    public float currenthealth = 0.0f;
    public float healthregen = 0.0f;

    public float maxmana = 0.0f;
    public float currentmana = 0.0f;
    public float manaregen = 0.0f;


    [Header("Extras")]
    public float armor = 0.0f;
    public float magicresist = 0.0f;

    //Slider for Stats
    public Slider HealthSlider;
    public Slider ManaSlider;

    public void Update()
    {
        HealthSlider.value = currenthealth;
        ManaSlider.value = currentmana;
    }

}
