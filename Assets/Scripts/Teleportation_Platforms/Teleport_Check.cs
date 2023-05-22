using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport_Check : MonoBehaviour
{
    
    public GameObject XR_Player;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Tutorial");
    }
}
