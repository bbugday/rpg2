using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyList;
    [SerializeField] List<Enemy> spawningEnemies;

    private int spawningEnemyCount = 0;

    void Start() 
    {
        spawningEnemies.Add(enemyList[spawningEnemyCount++]);
        Invoke("AddEnemy", 1 * 60f);
        Invoke("AddEnemy", 2 * 60f);
        Invoke("AddEnemy", 3 * 60f);
        Invoke("AddEnemy", 5 * 60f);
        Invoke("AddEnemy", 8 * 60f);
        Invoke("AddEnemy", 12 * 60f);

        // Invoke("AddEnemy", 1 * 40f);
        // Invoke("AddEnemy", 1 * 40f);
        // Invoke("AddEnemy", 1 * 40f);
        // Invoke("AddEnemy", 10 * 60f);
        // Invoke("AddEnemy", 15 * 60f);
        // Invoke("AddEnemy", 20 * 60f);

        InvokeRepeating("SpawnEnemy", 1f, 4f);  //1s delay, repeat every 1s
    }

    void OutputTime() 
    {
        Debug.Log(Time.time);
    }


    void SpawnEnemy() 
    {
        //Instantiate(enemyList[Random.Range(0, enemyList.Count)], gameObject.transform.position, Quaternion.identity);
        //Instantiate(enemyList[0], gameObject.transform.position, Quaternion.identity);
        Instantiate(spawningEnemies[Random.Range(0, spawningEnemies.Count)], gameObject.transform.position, Quaternion.identity);
    }

    void AddEnemy() 
    {
        spawningEnemies.Add(enemyList[spawningEnemyCount++]);
    }
}
