using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEntity : MonoBehaviour
{

    void OnCollisionEnter (Collision coll)
    {
        if (coll.gameObject.tag == "Dummy") {
            Destroy(gameObject);
            Debug.Log("Hit");
        }
    }
}