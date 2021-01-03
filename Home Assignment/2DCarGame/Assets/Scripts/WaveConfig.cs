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

    public GameObject getObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> getWaypoints()
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

    public float getTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float getSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int getNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float getObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
