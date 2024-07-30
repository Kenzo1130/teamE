using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;          // �X�|�[��������v���n�u
        public float spawnProbability;     // �X�|�[���m���i0����1�͈̔́j
    }

    public SpawnableObject[] objectsToSpawn;  // �X�|�[���\�ȃI�u�W�F�N�g�̃��X�g
    public float initialSpawnInterval = 5.0f; // �����̃X�|�[���Ԋu
    public float minSpawnInterval = 1.0f;     // �ŏ��̃X�|�[���Ԋu
    public float intervalDecreaseRate = 0.1f; // �X�|�[���Ԋu�̌�����
    public float decreaseIntervalTime = 30.0f; // �X�|�[���Ԋu����������܂ł̎���

    private float currentSpawnInterval; // ���݂̃X�|�[���Ԋu
    private float timeSinceLastDecrease; // �Ō�ɃX�|�[���Ԋu���������Ă���̎���
    private int maxSpawnedObjects = 10;  // �ő�X�|�[���I�u�W�F�N�g��

    public Vector2 spawnRangeMin; // �X�|�[���͈͂̍ŏ��l
    public Vector2 spawnRangeMax; // �X�|�[���͈͂̍ő�l

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
        if (GameObject.FindGameObjectsWithTag("Spawned").Length < maxSpawnedObjects) // �^�O���g���ăX�|�[�����𐧌�
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnRangeMin.x, spawnRangeMax.x),
                Random.Range(spawnRangeMin.y, spawnRangeMax.y)
            );

            GameObject prefabToSpawn = SelectRandomPrefab();
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    GameObject SelectRandomPrefab()
    {
        float totalProbability = 0f;
        foreach (var obj in objectsToSpawn)
        {
            totalProbability += obj.spawnProbability;
        }

        if (totalProbability > 1f)
        {
            Debug.LogWarning("���v�m����1�𒴂��Ă��܂��B�m�����������Ă��������B");
            return objectsToSpawn[0].prefab; // �f�t�H���g�ōŏ��̃v���n�u��Ԃ�
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

        return objectsToSpawn[0].prefab; // �f�t�H���g�ōŏ��̃v���n�u��Ԃ�
    }
}
