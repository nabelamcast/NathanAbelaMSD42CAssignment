using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // A list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    // Waves of obstacles will keep on spawning
    [SerializeField] bool looping = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            // Starts the coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); // (looping == true)
    }

    // While calling Coroutine it specifies which wave needs to spawn obstacles from
    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveToSpawn)
    {
        // Loop to spawn all obstacles in wave
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.GetNumberOfObstacles(); obstacleCount++)
        {
            // Spawn the obstacle from waveConfig at the position specified by waveConfig waypoints
            var newObstacle = Instantiate(
                            waveToSpawn.GetObstaclePrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);

            // Wave will be selected from here and the obstacle applied to it
            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
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
