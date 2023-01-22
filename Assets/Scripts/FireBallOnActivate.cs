using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBallOnActivate : MonoBehaviour
{

    public GameObject fireBall;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(fireProjectile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fireProjectile(ActivateEventArgs arg)
    {
        GameObject spawnedFireBall = Instantiate(fireBall);
        spawnedFireBall.transform.position = spawnPoint.position;
        spawnedFireBall.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;

        Destroy(spawnedFireBall, 5);
    }

}
