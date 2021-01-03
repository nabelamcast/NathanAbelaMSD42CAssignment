using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float obstacleMoveSpeed = 4f;

    [SerializeField] WaveConfig waveConfig;

    // Saves the waypoint in which it will go
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get the list waypoints from WaveConfig
        //waypoints = waveConfig.getWaypoints();

        // Set the start position of Enemy to the 1st waypoint position
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            // Saves the current waypoint in targetPosition
            // targetPosition is where obstacle will go
            var targetPosition = waypoints[waypointIndex].transform.position;

            // Making sure z-axis position is 0	
            targetPosition.z = 0f;

            // Obstacle movement speed at each frame
            var obstacleMovement = waveConfig.getObstacleMoveSpeed() * Time.deltaTime;

            // Move Obstacle from current position to targetPosition, at obstacleMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

            // If obstacle reaches the target position
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        // If obstacle reaches last waypoint
        else
        {
            Destroy(gameObject);
        }
    }

    // Set up a WaveConfig
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        //waveConfig = waveConfigToSet;
    }
}
