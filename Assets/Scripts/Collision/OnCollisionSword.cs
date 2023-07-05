using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSword : MonoBehaviour
{

    int countDummy = 0;
    int countEnemy = 0;

    SoundManager playAudio;
    public bool grabbed;

    void Awake()
    {
        playAudio = GetComponent<SoundManager>();
    }

    private void GrabSound() 
    {
        playAudio.audioSource.PlayOneShot(playAudio.clipGrabSword, playAudio.volume);
    }

    void OnCollisionEnter (Collision coll)
    {

        //Get Enemy currenthealth
        stats_Enemy enemyHealth = coll.gameObject.GetComponent<stats_Enemy>();

        //Get Sword damage
        stats_Sword swordDamage = this.gameObject.GetComponent<stats_Sword>();

        if (coll.gameObject.tag == "Dummy") {
            countDummy++;
            Debug.Log("Sword Hit:" + countDummy);

            //Crit mechanic
            float randValue = Random.value;
            float critChancePerc = swordDamage.critchance * 100;
            if (randValue < critChancePerc) //Doesnt crit
            {
                enemyHealth.currenthealth = enemyHealth.currenthealth - swordDamage.attackdamage;
            }
        
            else //Crit
            {
                enemyHealth.currenthealth = enemyHealth.currenthealth - (swordDamage.attackdamage * 2);
            }
        }

        if (coll.gameObject.tag == "Enemy") {

            //Crit mechanic
            float randValue = Random.value;
            float critChancePerc = swordDamage.critchance * 100;
            if (randValue < critChancePerc) //Doesnt crit
            {
                enemyHealth.currenthealth = enemyHealth.currenthealth - swordDamage.attackdamage;
            }
        
            else //Crit
            {
                enemyHealth.currenthealth = enemyHealth.currenthealth - (swordDamage.attackdamage * 2);
            }
        }
    }
}