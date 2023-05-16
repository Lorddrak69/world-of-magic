using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats_Sword : MonoBehaviour
{

    [Header("Base")]
    public float attackdamage = 0.0f;
    public float critdamage = 0.0f;
    public float critchance = 0.0f;

    [Header("Extras")]
    public bool Bleed = false;
    public float Bleed_dps_Damage = 0.0f;

}
