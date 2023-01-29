using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBallOnActivate : MonoBehaviour
{

    public GameObject fireBall;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(fireProjectile);
    }

    public void fireProjectile(ActivateEventArgs arg)
    {
        //Clone the fireBall object
        GameObject spawnedFireBall = Instantiate(fireBall);

        // Where the fireball will spawn and in what direction
        spawnedFireBall.transform.position = spawnPoint.position;
        spawnedFireBall.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;

        // Start despawning projectiles once reaches 5 in the scene
        Destroy(spawnedFireBall, 5);
    }

}
