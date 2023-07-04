using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    public bool isActive;
    public bool isCompleted;
    public string title;
    public string description;

    void Start()
    {
        isActive = true;
        isCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}