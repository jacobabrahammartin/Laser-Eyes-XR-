using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    public Transform spawnPoint; // Point from where enemies will spawn
    public float spawnInterval = 2f; // Time interval between each spawn
    public int maxEnemies = 30; // Maximum number of enemies to spawn

    private int enemiesDestroyed = 0; // Counter for enemies destroyed
    private float spawnTimer = 0f; // Timer for spawning enemies

    void Update()
    {
        // If the maximum number of enemies have been destroyed, stop spawning
        if (enemiesDestroyed >= maxEnemies)
        {
            enabled = false; // Disable this script
            return;
        }

        // Update spawn timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f; // Reset spawn timer
        }
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy prefab at the spawn point
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Attach a script to the instantiated enemy to track when it's destroyed
        HS_HittedObject enemyHealth = enemy.GetComponent<HS_HittedObject>();
        if (enemyHealth != null)
        {
          //  enemyHealth.OnDeat += OnEnemyDestroyed;
        }
    }

    // Method to handle when an enemyis destroyed
    void OnEnemyDestroyed()
    {
        enemiesDestroyed++;

        // If the maximum number of enemies have been destroyed, stop spawning
        if (enemiesDestroyed >= maxEnemies)
        {
            enabled = false; // Disable this script
        }
    }
}