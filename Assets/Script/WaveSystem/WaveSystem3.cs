using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPoint;
    public float timeBetweenWaves = 30f;
    private float countdown = 3f;
    private int WaveIndex = 0;
    private bool DoneSpawn = false;
    List<GameObject> enemyActiveList;
    private void Start()
    {
        enemyActiveList = new List<GameObject>();
    }
    private void Update()
    {
        if (countdown <= 0f || enemyActiveList.Count == 0 && DoneSpawn == true)
        {
            StartCoroutine(SpawnWave());

            if (WaveIndex > 10)
            {
                countdown = timeBetweenWaves - (1 * WaveIndex);
            }
            else
            {
                countdown = timeBetweenWaves - 10;
            }
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        WaveIndex++;
        for (int i = 0; i < enemyActiveList.Count; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.1f);
        }
    
    }
    void SpawnEnemy()
    {
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);
        GameObject PickedPoint = spawnPoint[spawnPointIndex];
        Vector3 PickedPointPosition = PickedPoint.transform.position;

        GameObject Enemy = Instantiate(enemyPrefab);
        Enemy.transform.position = PickedPointPosition;

        enemyActiveList.Add(Enemy);

    }

}
