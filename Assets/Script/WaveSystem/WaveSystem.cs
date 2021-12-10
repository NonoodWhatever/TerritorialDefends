using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    // https://www.youtube.com/watch?v=gtVQDqFdabs
    private int waveNumber = 0;
    public int enemySpawnAmount = 0;
    public int enemiesKilled = 0;
    public GameObject[] SpawnPoints;
    public GameObject enemy;
    bool DoneSpawning = false;
   List<GameObject> enemyLister;
    void Start()
    {
       enemyLister = new List<GameObject>();
        SpawnPoints = new GameObject[5];

        for(int i= 0; i < SpawnPoints.Length; i++)
        {
            SpawnPoints[i] = transform.GetChild(i).gameObject;
        }
        StartWave();
    }

    // Update is called once per frame
void Update()
  {
       if(enemiesKilled >= enemySpawnAmount && DoneSpawning == true)
       {
           NextWave();
       }
  }
    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, SpawnPoints.Length);
        Instantiate(enemy, SpawnPoints[spawnerID].transform.position, SpawnPoints[spawnerID].transform.rotation);
        enemyLister.Add(enemy);
    }
    private void StartWave()
    {
        DoneSpawning = false;
        waveNumber = 1;
        enemySpawnAmount = 2;
        enemiesKilled = 0;
        for(int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
        DoneSpawning = true;
    }
    public void NextWave()
    {
        DoneSpawning = false;
        waveNumber++;
        enemySpawnAmount *= 2;
        enemiesKilled = 0;

        for(int i = 0; i< enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
        DoneSpawning = true;
    }
}
