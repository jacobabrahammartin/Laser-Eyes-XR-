using UnityEngine;

public class PingpongMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float speed = 2.0f; // Speed of movement

    private int currentWaypointIndex = 0;

    void Update()
    {
        // Check if there are any waypoints
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to LoopingMovement script.");
            return;
        }

        // Calculate the direction towards the current waypoint
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;

        // Move towards the current waypoint
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the object has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex++;

            // If reached the last waypoint, loop back to the first waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}