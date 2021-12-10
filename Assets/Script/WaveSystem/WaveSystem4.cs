using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem4 : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };



    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float SpawnRate;
    }

    public Wave[] Waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private SpawnState state = SpawnState.COUNTING;
    private float searchCountdown = 1f;
   //private int NewSpawnGMCountdown = 0;
   // public int NewSpawnGMCritPoint = 4;
    public GameObject MoreSpawner;
    private void Start()
    {
       waveCountdown = timeBetweenWaves;
    }
    private void OnEnable()
    {
       // waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
            if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                NewRound();
            }
            else
            {
                return;
            }
        }
        
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(Waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

        


    }
    void NewRound()
    {
        Debug.LogError("ALL ENEMY DEAD");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > Waves.Length - 1)
        {
            nextWave = 0;
            Debug.LogError("REPEAT");
            MoreSpawner.SetActive(true);
        }
        else 
        { 
            nextWave++;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        //spawn
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1/_wave.SpawnRate);
        }
        
        state = SpawnState.WAITING;

        yield break;
    }


    void SpawnEnemy(Transform _enemy)
    {
        
        Debug.Log("SpawnBad" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range (0,spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }


}
