using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 5f;
    [SerializeField] int maxEnemies =10;
    int spawnedEnemies = 0;

    private void Start()
    {
       // StartSpawning();
    }
    private void OnEnable()
    {
        EventManager.onStartGame += StartSpawning;
        EventManager.onPlayerDeath += StopSpawning;
    }
    private void OnDisable()
    {
        //StopSpawning();
        EventManager.onStartGame -= StartSpawning;
        EventManager.onPlayerDeath -= StopSpawning;

    }

    void SpawnEnemy()
    {
        if(spawnedEnemies < maxEnemies)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnedEnemies++;
        }
        
        
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    void StopSpawning()
    {
        CancelInvoke();
        spawnedEnemies = 0;
    }
}
