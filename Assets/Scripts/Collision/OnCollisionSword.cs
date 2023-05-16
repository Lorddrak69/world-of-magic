using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSword : MonoBehaviour
{

    int count = 0;

    void OnCollisionEnter (Collision coll)
    {
        if (coll.gameObject.tag == "Dummy") {
            count++;
            Debug.Log("Sword Hit:" + count);
        }
    }
}