using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 5.0f;
    public Vector2 spawnRangeMin;
    public Vector2 spawnRangeMax;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0, spawnInterval);
    }

    private void Update()
    {
        
    }
    void SpawnObject()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnRangeMin.x, spawnRangeMax.x),
            Random.Range(spawnRangeMin.y, spawnRangeMax.y)
        );
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
