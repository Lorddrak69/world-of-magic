using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int spawnCount = 6;
    public int cooldown = 5;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    void Update()
    {
        
    }

    public void ForceSpawn() 
    {
        xPos = Random.Range(485, 586);
        zPos = Random.Range(662, 841);
        Instantiate(theEnemy, new Vector3(xPos, 37, zPos), Quaternion.identity);
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < spawnCount)
        {
            xPos = Random.Range(485, 586);
            zPos = Random.Range(662, 841);
            Instantiate(theEnemy, new Vector3(xPos, 37, zPos), Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
            enemyCount += 1;
        }
    }

}