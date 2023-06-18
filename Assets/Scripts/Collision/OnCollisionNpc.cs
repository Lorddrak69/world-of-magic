using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionNpc : MonoBehaviour
{

    public Canvas npcmaincanvas;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            npcmaincanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            npcmaincanvas.gameObject.SetActive(false);
        }
    }
}
