using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{

    public float fireSpeed;

    void Update()
    {
        this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, fireSpeed));
    }
}
