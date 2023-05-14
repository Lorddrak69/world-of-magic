using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBall_WSpell : MonoBehaviour
{

    public GameObject fire;
    public Transform spawnPoint;
    public float spellSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(fireSpell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fireSpell(ActivateEventArgs arg)
    {
        GameObject spawnedFire = Instantiate(fire);
        spawnedFire.transform.position = spawnPoint.position;
        spawnedFire.GetComponent<Rigidbody>().velocity = spawnPoint.forward * spellSpeed;
        Destroy(spawnedFire,5);
    }
}
