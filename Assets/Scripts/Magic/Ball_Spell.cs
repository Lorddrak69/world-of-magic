using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBall_WSpell : MonoBehaviour
{

    [SerializeField] private OnCollisionWand fireBallPrefab;

    public stats_Player statsPlayer;

    public bool IsAvailable;
    public float CooldownDuration = 1.5f;

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
        IsAvailable = true;
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(fireSpell);
    }

    public void fireSpell(ActivateEventArgs arg)
    {
        if (IsAvailable == false)
        {
            return;
        }
        else
        {
            if (statsPlayer.currentmana >= WandStats.manausage)
            {
                StartCoroutine(StartCooldown());
                OnCollisionWand spawnedFire = Instantiate(fireBallPrefab);
                spawnedFire.transform.position = spawnPoint.position;
                spawnedFire.Initialize(this);
                spawnedFire.ApplyForce(spellSpeed, spawnPoint.forward);
                Destroy(spawnedFire,5);
                statsPlayer.currentmana -= WandStats.manausage;
            }
        }
    }

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;

        yield return new WaitForSeconds(CooldownDuration);

        IsAvailable = true;
    }
}
