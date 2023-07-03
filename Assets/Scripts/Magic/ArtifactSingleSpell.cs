using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArtifactSingleSpell : MonoBehaviour
{

    [SerializeField] public GameObject Spell;

    public bool IsAvailable;
    public float CooldownDuration = 30f;

    Stats_Artifact ArtifactStats;
    public stats_Player statsPlayer;
    public Transform spawnPoint;

    public float destroyTime = 10f;

    void Start()
    {
        IsAvailable = true;
        ArtifactStats = gameObject.GetComponent<Stats_Artifact>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(ArtifactSpell);
    }

    public void ArtifactSpell(ActivateEventArgs arg)
    {
        if (IsAvailable == false)
        {
            return;
        }
        else
        {
            if (statsPlayer.currentmana >= ArtifactStats.manausage)
            {
                StartCoroutine(StartCooldown());
                GameObject spawnedSpell = Instantiate(Spell);
                spawnedSpell.transform.position = spawnPoint.position;
                Destroy(spawnedSpell, destroyTime);
                Debug.Log(ArtifactStats.manausage);
                Debug.Log(statsPlayer.currentmana);
                statsPlayer.currentmana -= ArtifactStats.manausage;
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
