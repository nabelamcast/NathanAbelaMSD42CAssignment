using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // A list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    // Always start from Wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            // Start the coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); // (looping == true)
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When calling Coroutine, specify which Wave we need to spawn obstacles from
    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveToSpawn)
    {
        // Loop to spawn all obstacles in wave
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.getNumberOfObstacles(); obstacleCount++)
        {
            // Spawn the obstacle from waveConfig at the position specified by waveConfig waypoints
            var newObstacle = Instantiate(
                            waveToSpawn.getObstaclePrefab(),
                            waveToSpawn.getWaypoints()[0].transform.position,
                            Quaternion.identity);

            // The wave will be selected from here and the obstacle applied to it
            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.getTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        // Loop all waves
        foreach (WaveConfig currentWave in waveConfigList)
        {
            // Wait for all obstacles to spawn before going to the next wave
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }
}
