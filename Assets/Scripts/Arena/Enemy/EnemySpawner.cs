using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyList;
    
    void Start() 
    {
        InvokeRepeating("SpawnEnemy", 1f, 4f);  //1s delay, repeat every 1s
    }

    void OutputTime() 
    {
        Debug.Log(Time.time);
    }


    void SpawnEnemy() 
    {
        Instantiate(enemyList[Random.Range(0, enemyList.Count)], gameObject.transform.position, Quaternion.identity);
    }
}
