using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMission : MonoBehaviour
{
    public bool isActive {get;set;}
    public bool isCompleted {get;set;}
    public bool rewarded;
    public int enemyKillCount;
    public string title;
    public string description;

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
        isActive = false;
        isCompleted = false;
        rewarded = false;

        enemyKillCount = 0;

    }

    void Update()
    {
        if (isCompleted && !rewarded)
        {
            Rewards();
            isActive = false;
        }
        
        if ((isActive) && (enemyKillCount >= 5))
        {
            isCompleted = true;
        }
    }

    void Rewards()
    {
        statsPlayer.currentExperience += experience;
        rewarded = true;
    }
}
