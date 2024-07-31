using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;
        public float spawnProbability; // 0 to 1
        public float fallSpeed = 1.0f; // 落下速度
    }

    public SpawnableObject[] objectsToSpawn;
    public float initialSpawnInterval = 5.0f;
    public float minSpawnInterval = 1.0f;
    public float intervalDecreaseRate = 0.1f;
    public float decreaseIntervalTime = 30.0f;

    private float currentSpawnInterval;
    private float timeSinceLastDecrease;

    public Vector2 spawnRangeMin;
    public Vector2 spawnRangeMax;

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

        GameObject prefabToSpawn = SelectRandomPrefab(out float fallSpeed);
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Rigidbody2DのVelocityを設定
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -fallSpeed);
        }
    }

    GameObject SelectRandomPrefab(out float fallSpeed)
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
                fallSpeed = obj.fallSpeed;
                return obj.prefab;
            }
            else
            {
                randomPoint -= obj.spawnProbability;
            }
        }

        fallSpeed = objectsToSpawn[0].fallSpeed;
        return objectsToSpawn[0].prefab; // デフォルトで最初のプレハブを返す
    }
}
