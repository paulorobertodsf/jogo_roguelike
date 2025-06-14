using System.IO;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] private string idEnemy;
    public float minDistance;
    public float maxDistance;
    public float spawnInterval;

    private float nextSpawnTime;

    private static string jsonEnemies = "Enemies.json";

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        float distance = Random.Range(minDistance, maxDistance);
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)transform.position + direction * distance;

        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        EnemyStats enemyStats = enemyInstance.GetComponent<EnemyStats>();
        EnemyModel enemyModel = EnemyStatsLoad();
        enemyStats.Initialize(enemyModel);
    }

    private EnemyModel EnemyStatsLoad()
    {
        string path = Path.Combine(GameController.pathData, jsonEnemies);
        string json = File.ReadAllText(path);
        EnemiesWrapper wrapper = JsonUtility.FromJson<EnemiesWrapper>(json);
        EnemyModel enemyModel = wrapper.enemies.Find(e => e.id == idEnemy);
        return enemyModel;
    }
}
