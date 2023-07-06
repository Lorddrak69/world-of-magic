using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    public bool isActive {get;set;}
    public bool isCompleted {get;set;}
    public string title;
    public string description;
    public bool rewarded;

    [Header("Rewards")]
    public int experience;
    public int gold;

    public GameObject Player;
    public stats_Player statsPlayer;

    void Awake()
    {
        Player = GameObject.Find("XR Origin");
        statsPlayer = Player.GetComponent<stats_Player>();
    }

    void Start()
    {
        isActive = true;
        isCompleted = false;
        rewarded = false;
    }

    void Update()
    {
        if (isCompleted && !rewarded)
        {
            Rewards();
        }
    }

    void Rewards()
    {
        statsPlayer.currentExperience += experience;
        rewarded = true;
    }
}