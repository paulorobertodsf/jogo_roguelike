using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Transform Container;
    public Transform player;

    public float distanciaMin = 5f;
    public float distanciaMax = 10f;
    public float tempoEntreSpawn = 3f;

    public float tempoProxSpawn;

    void Update()
    {
        if (Time.time >= tempoProxSpawn)
        {
            SpawnInimigo();
            tempoProxSpawn = Time.time + tempoEntreSpawn;
        }   
    }

    void SpawnInimigo()
    {
        Debug.Log(player, prefabEnemy);
        if (player == null || prefabEnemy == null) return;

        Vector2 direcao = Random.insideUnitCircle.normalized;
        float distancia = Random.Range(distanciaMin, distanciaMax);
        Vector2 posicaoSpawn = (Vector2) player.position + direcao * distancia;

        Instantiate(prefabEnemy, posicaoSpawn, Quaternion.identity, Container);
    }
}
