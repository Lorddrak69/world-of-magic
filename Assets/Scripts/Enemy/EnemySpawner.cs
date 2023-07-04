using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 6)
        {
            xPos = Random.Range(485, 586);
            zPos = Random.Range(662, 841);
            Instantiate(theEnemy, new Vector3(xPos, 37, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5);
            enemyCount += 1;
        }
    }

}
