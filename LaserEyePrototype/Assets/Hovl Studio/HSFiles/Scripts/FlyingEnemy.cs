using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public Transform player;
    public float minDistance = 5f;
    public float maxDistance = 10f;
    public float movementSpeed = 5f;

    private Vector3 targetPosition;

    void Start()
    {
        // Set initial target position
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // If the enemy reaches the target position, set a new random target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }
    }

    // Get a random position within the specified range around the player
    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * Random.Range(minDistance, maxDistance);
        randomDirection += player.position;
        randomDirection.y = Mathf.Clamp(randomDirection.y, 0f, 10f); // Adjust this value according to your scene
        return randomDirection;
    }
}