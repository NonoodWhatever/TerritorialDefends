using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerLivingBulletSpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float SpawnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTime -= Time.deltaTime;
        if(SpawnTime <= 0)
        {
            Instantiate(ObjectToSpawn, transform.position, transform.rotation);
            SpawnTime = 10f;
        }
    }
}
