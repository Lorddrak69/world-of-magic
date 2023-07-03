using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBall_WSpell : MonoBehaviour
{

    [SerializeField] private OnCollisionWand fireBallPrefab;

    public stats_Player statsPlayer;

    public stats_Wand WandStats {get; private set; }
    public Transform spawnPoint;
    public float spellSpeed = 20;

    private void Awake()
    {
        WandStats = GetComponent<stats_Wand>();
    }

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(fireSpell);
    }

    public void fireSpell(ActivateEventArgs arg)
    {
        OnCollisionWand spawnedFire = Instantiate(fireBallPrefab);
        spawnedFire.transform.position = spawnPoint.position;
        spawnedFire.Initialize(this);
        spawnedFire.ApplyForce(spellSpeed, spawnPoint.forward);
        Destroy(spawnedFire,5);
        statsPlayer.currentmana -= WandStats.manausage;
    }
}
