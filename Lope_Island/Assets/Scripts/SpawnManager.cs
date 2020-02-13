using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRange = 10;
    Vector3 spawnRandomPosition;
    public float minMassRange = 0.5f;
    public float maxMassRange = 2.5f;

    int waves = 1;
    public GameObject powerUpPrefab;

    GameObject player;
    Vector3 inicialPosition;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(1);
        Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);

        player = GameObject.Find("Player");
        inicialPosition = player.transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        int enemiesCount = FindObjectsOfType<Enemy>().Length;
        if (enemiesCount == 0)
        {
            waves++;
            SpawnEnemyWave(waves);
            Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);
        
        }
        if (player.transform.position.y == -10)
        {
            player.transform.position == inicialPosition
        }
        if (Input.anyKeyDown && player == null)
        {
            Instantiate(player, player.transform.position, player.transform.rotation);
        }
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
            Rigidbody enemyRB = enemy.GetComponent<Rigidbody>();
            Enemy enemyScript = enemy.GetComponent<Enemy>();


            enemyRB.mass = Random.Range(minMassRange, maxMassRange);
            float currentMass = enemyRB.mass;
            enemy.transform.localScale = new Vector3(currentMass, currentMass, currentMass);
            enemyScript.speed = enemyScript.speed + currentMass;

           
            
        }
    }
}
