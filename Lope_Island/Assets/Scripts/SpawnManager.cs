using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRange = 10;
    Vector3 spawnRandomPosition;
    public float minMassRange = 0.5f;
    public float maxMassRange = 2.5f;
    public bool isGameOver;

    int waves = 1;
    public GameObject powerUpPrefab;

    public GameObject player;
    GameObject canvas;
    Vector3 inicialPosition;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(1);
        Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);

        player = GameObject.Find("Player");
        //string lifes = "3"; // function to change from string to Integer
        //lifesInt = lifesInt - 2;
        inicialPosition = player.transform.position;
        canvas = GameObject.Find("Canvas");
        gameOverText = canvas.transform.GetChild(0).GetComponent<Text>();
        gameOverText.enabled = false; // set unactive the text

    }
    

    // Update is called once per frame
    void Update()
    {
        int enemiesCount = FindObjectsOfType<Enemy>().Length;
        if (enemiesCount == 0 && !isGameOver)
        {
            waves++;
            SpawnEnemyWave(waves);
            Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);
        
        }
        if (player.transform.position.y <= -10)
        {
            isGameOver = true;
            gameOverText.enabled = true;
            if (Input.anyKeyDown)// the player has dissapeared
            {
                RestartGame();

            }
        }
        if (Input.anyKeyDown && player == null)
        {
            Instantiate(player, player.transform.position, player.transform.rotation);
        }
    }

    void RestartGame()
    {

        player.transform.position = inicialPosition;
        waves = 1;
        SpawnEnemyWave(waves);
        isGameOver = false;
        gameOverText.enabled = false;
        int powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;
        if(powerupCount == 0)
        {
            Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);
        }
        else if (powerupCount > 1)
        {
            for (int i = 0; i < powerupCount; i++)
            {
                GameObject PowerupToDestroy = GameObject.FindGameObjectWithTag("Powerup");
                Destroy(PowerupToDestroy);
            }
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

            GameObject enemy = Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
            Rigidbody enemyRB = enemy.GetComponent<Rigidbody>();
            Enemy enemyScript = enemy.GetComponent<Enemy>();


            enemyRB.mass = Random.Range(minMassRange, maxMassRange);
            float currentMass = enemyRB.mass;
            enemy.transform.localScale = new Vector3(currentMass, currentMass, currentMass);
            enemyScript.speed = enemyScript.speed + currentMass;

           
            
        }
    }
}
