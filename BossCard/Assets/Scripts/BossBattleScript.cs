using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleScript : MonoBehaviour
{    
    int vidaJefe;
    bool battleActive = false;
    int activeEnemies = 0;
    int currentWave = 0;
    bool battleEnded = false;

    private List<Vector3> spawnPositionsList;

    public GameObject spawnEnemies;

    public Animator aniCon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        spawnPositionsList = new List<Vector3>();
        foreach (Transform SpawnPositions in transform.Find("Spawner"))
        {
            spawnPositionsList.Add(SpawnPositions.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!battleActive) 
        { 
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                battleActive = true;
                StartBattle();
            }
        }
    }

    private void StartBattle()
    {
        Debug.Log("Battle Started");
        StartNextWave();
    }
    private void Wave1() 
    {
        activeEnemies = 5;
        Debug.Log("Wave 1 Started with " + activeEnemies + " enemies");
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy();
        }
    }

    private void Wave2() 
    {
        activeEnemies = 10;
        Debug.Log("Wave 2 Started with " + activeEnemies + " enemies");
        for (int i = 0; i < 10; i++)
        {
            SpawnEnemy();
        }
    }
    private void EndBattle()
    {
        Debug.Log("Battle Ended");
        battleEnded = true;

        aniCon.Play("bossMuerte");
        GameObject fire = transform.Find("Explosion").gameObject;
        if (fire != null)
        {
            fire.SetActive(true);
            Debug.Log("Spawner deactivated");
        }
        else
        {
            Debug.LogError("Spawner GameObject not found!");
        }
        Invoke("CloseGame", 5f);
    }

    private void StartNextWave()
    {
        if (battleEnded) return;

        switch (currentWave)
        {
            case 0:
                Wave1();
                break;
            case 1:
                Wave2();
                break;
            default:
                EndBattle();
                break;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = spawnPositionsList[Random.Range(0, spawnPositionsList.Count)];
        GameObject enemy = Instantiate(spawnEnemies, spawnPos, transform.rotation);

        Debug.Log("Spawned Enemy at " + spawnPos);

        enemyScript eneScrip = enemy.GetComponent<enemyScript>();
        if (eneScrip != null)
        {
            eneScrip.OnDeath += OnEnemyDeath;
        }
        else
        {
            Debug.LogError("Spawned object does not have an EnemyScript!");
        }

        // Invoke("CloseGame", 5f); // Close the game after 5 seconds
    }

    private void CloseGame()
    {
        Debug.Log("Closing Game...");
        Application.Quit();
    }

    private void OnEnemyDeath()
    {
        activeEnemies = Mathf.Max(0, activeEnemies - 1);
        Debug.Log("Enemy Died. Active enemies remaining: " + activeEnemies);
        if (activeEnemies <= 0)
        {
            currentWave++;
            StartNextWave();
        }
    }
}
