using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(Starting());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
        while (isLooping);
    }
}