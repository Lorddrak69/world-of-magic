using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapPoint : MonoBehaviour
{

    public Transform Left;
    public Transform Right;
    public Transform MainAttach;

    void OnTriggerEnter(Collider other) {  
        if (other.gameObject.name == "RightHand")
        {
            MainAttach = Right;
        }
        if(other.gameObject.name == "LeftHand")
        {
            MainAttach = Left;
        }
    }  
}
