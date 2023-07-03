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

    [Header("Checks")]
    public bool isRegenHealth;
    public bool isRegenMana;


    [Header("Extras")]
    public float armor = 0.0f;
    public float magicresist = 0.0f;

    //Slider for Stats
    public Slider HealthSlider;
    public Slider ManaSlider;

    public void Update()
    {
        if(currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }

        if(currentmana > maxmana)
        {
            currentmana = maxmana;
        }

        if(currenthealth != maxhealth && !isRegenHealth)
        {
            StartCoroutine(RegainHealthOverTime());
        }

        if(currentmana != maxmana && !isRegenMana)
        {
            StartCoroutine(RegainManaOverTime());
        }

        HealthSlider.value = currenthealth;
        ManaSlider.value = currentmana;
    }

    IEnumerator RegainHealthOverTime()
    {
        isRegenHealth = true;
        while(currenthealth < maxhealth)
        {
            HealthRegen();
            yield return new WaitForSeconds(1);
        }
        isRegenHealth = false;
    }

    IEnumerator RegainManaOverTime()
    {
        isRegenMana = true;
        while(currentmana < maxmana)
        {
            ManaRegen();
            yield return new WaitForSeconds(1);
        }
        isRegenMana = false;
    }

    public void HealthRegen()
    {
        currenthealth += healthregen;
    }

    public void ManaRegen()
    {
        currentmana += manaregen;
    }

}
