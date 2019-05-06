using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class is going to create all the enemies based on the type of wave (WaveConfig),
 * which contains the type of path (EnemyPath), type of enemies and other parameters.
 */
public class EnemySpawner : MonoBehaviour {

    //Configuration parameters
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    /*
     * Changed to IEnumerator in order to be a coroutine.
     * If it wasn't IEnumerator, the game would never start.
     * Making this IEnumerator, allows Start method to wait for SpawnAllWaves() to finish;
     * after SpawnAllWaves() finishes, the loop continues.
     */    
    IEnumerator Start () {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves() {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Capacity; waveIndex++) {
            var currentWave = waveConfigs[waveIndex];
            //This coroutine is waiting for the other coroutine
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++) {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
