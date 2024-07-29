using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;          // スポーンさせるプレハブ
        public float spawnProbability;     // スポーン確率（0から1の範囲）
    }

    public SpawnableObject[] objectsToSpawn;  // スポーン可能なオブジェクトのリスト
    public float initialSpawnInterval = 5.0f; // 初期のスポーン間隔
    public float minSpawnInterval = 1.0f;     // 最小のスポーン間隔
    public float intervalDecreaseRate = 0.1f; // スポーン間隔の減少率
    public float decreaseIntervalTime = 30.0f; // スポーン間隔が減少するまでの時間

    private float currentSpawnInterval; // 現在のスポーン間隔
    private float timeSinceLastDecrease; // 最後にスポーン間隔が減少してからの時間

    public Vector2 spawnRangeMin; // スポーン範囲の最小値
    public Vector2 spawnRangeMax; // スポーン範囲の最大値

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval; 
        timeSinceLastDecrease = 0.0f;
        InvokeRepeating("SpawnObject", 0, currentSpawnInterval);
    }

    void Update()
    {
        timeSinceLastDecrease += Time.deltaTime;
        if (timeSinceLastDecrease >= decreaseIntervalTime)
        {
            timeSinceLastDecrease = 0.0f;
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - intervalDecreaseRate);
            CancelInvoke("SpawnObject");
            InvokeRepeating("SpawnObject", 0, currentSpawnInterval);
        }
    }

    void SpawnObject()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnRangeMin.x, spawnRangeMax.x),
            Random.Range(spawnRangeMin.y, spawnRangeMax.y)
        );

        GameObject prefabToSpawn = SelectRandomPrefab();
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    GameObject SelectRandomPrefab()
    {
        float totalProbability = 0f;
        foreach (var obj in objectsToSpawn)
        {
            totalProbability += obj.spawnProbability;
        }

        float randomPoint = Random.value * totalProbability;

        foreach (var obj in objectsToSpawn)
        {
            if (randomPoint < obj.spawnProbability)
            {
                return obj.prefab;
            }
            else
            {
                randomPoint -= obj.spawnProbability;
            }
        }

        return objectsToSpawn[0].prefab; // デフォルトで最初のプレハブを返す
    }
}

