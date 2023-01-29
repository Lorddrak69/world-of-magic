using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBallOnActivate : MonoBehaviour
{

    public GameObject fireBall;
    public Transform spawnPoint;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(fireProjectile);
    }

    public void fireProjectile(ActivateEventArgs arg)
    {
        Instantiate(fireBall, spawnPoint.transform.position, Quaternion.identity);
    }

}
