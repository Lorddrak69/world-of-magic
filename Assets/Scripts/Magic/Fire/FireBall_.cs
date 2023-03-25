using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBall_ : MonoBehaviour
{

    public GameObject fireBall;
    public Transform spawnPoint;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(fireBallUsage_);
    }

    public void fireBallUsage_(ActivateEventArgs arg)
    {
        GameObject newProjectile = Instantiate(fireBall, transform.position, Quaternion.identity);
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1000f);
    }

}
