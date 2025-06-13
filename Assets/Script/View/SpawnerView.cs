using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private string IdEnemy;
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

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
    }
}
