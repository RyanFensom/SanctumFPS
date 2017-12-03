using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour
{
    public GameObject enemy;
    public Transform[] enemySpawnpoint;

    float spawnRate = 2;
    float spawnDelay = 0;


    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            if (Time.time >= spawnDelay)
            {
                SpawnEnemy();
            }
        }
    }

    // Used to spawn enemy prefabs 
    void SpawnEnemy()
    {
        int spawnInt = Random.Range(0, 1);

        GameObject enemySpawn = (GameObject)Instantiate(enemy,
            enemySpawnpoint[spawnInt].position,
            enemySpawnpoint[spawnInt].rotation);
        NetworkServer.Spawn(enemySpawn);

        spawnDelay = spawnRate + Time.time;
    }
}
