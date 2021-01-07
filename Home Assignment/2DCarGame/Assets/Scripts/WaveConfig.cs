using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]

public class WaveConfig : ScriptableObject
{
    // The obstacle that will spawn in this wave
    [SerializeField] GameObject obstaclePrefab;

    // The path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    // The time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    // The random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    // The number of obstacles in each wave
    [SerializeField] int numberOfObstacles = 5;

    // The obstacle movement speed
    [SerializeField] float obstacleMoveSpeed = 2f;

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        // Each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        // Access pathPrefab and for each child
        // Add it to the List waveWayPoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }
}
