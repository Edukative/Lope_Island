﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRange = 10;
    Vector3 spawnRandomPosition;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateRandomPosition()
    {
        float spawnRandomX = Random.Range(-spawnRange, spawnRange);
        float spawnRandomZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnRandomPosition = new Vector3(spawnRandomX, 0, spawnRandomZ);
        Debug.Log("Random position" + spawnRandomPosition);
        return spawnRandomPosition;
    }

    void SpawnEnemyWave (int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {

            GameObject enemy =Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
            Rigidbody enemyRB = enemy.GetComponent<Rigidbody>;
            ene
        }
    }
}
