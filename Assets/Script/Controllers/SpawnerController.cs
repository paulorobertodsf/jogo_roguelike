using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float minDistance;
    public float maxDistance;
    public float spawnInterval;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        float distance = Random.Range(minDistance, maxDistance);
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)transform.position + direction * distance;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
    }
}
