using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public ObjectPool enemyPool;
    public float spawnRadius = 10f;
    public float spawnInterval = 2f;
    public Transform player;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

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
        // Calculate a random angle
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate a random position around the player within the spawn radius
        Vector2 spawnOffset = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * spawnRadius;
        Vector2 spawnPosition = (Vector2)player.position + spawnOffset;

        // Get an enemy object from the pool
        GameObject enemy = enemyPool.GetObjectFromPool();
        enemy.transform.position = spawnPosition;
        enemy.SetActive(true);
    }
}
