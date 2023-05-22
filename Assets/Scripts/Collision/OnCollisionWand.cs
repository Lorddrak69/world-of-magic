using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWand : MonoBehaviour
{

    private Rigidbody rb;
    private FireBall_WSpell caster;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize(FireBall_WSpell wand)
    {
        caster = wand;
    }

    public void ApplyForce(float force, Vector3 direction)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    void OnCollisionEnter (Collision coll)
    {

        //Get Enemy currenthealth
        stats_Enemy enemyHealth = coll.gameObject.GetComponent<stats_Enemy>();

        //Get Wand abilitypower
        float abilitypower = caster.WandStats.abilitypower;

        if (coll.gameObject.tag == "Dummy") {
            Debug.Log("Wand Hit: " + enemyHealth.currenthealth);
            Destroy(gameObject);
            enemyHealth.currenthealth = enemyHealth.currenthealth - abilitypower;
        }

        if (coll.gameObject.tag == "Enemy") {
            Debug.Log("Wand Hit: " + enemyHealth.currenthealth);
            Destroy(gameObject);
            enemyHealth.currenthealth = enemyHealth.currenthealth - abilitypower;
        }
    }
}