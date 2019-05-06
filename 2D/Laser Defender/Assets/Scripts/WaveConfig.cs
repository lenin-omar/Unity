using System.Collections.Generic;
using UnityEngine;

/*
 * Base configuration class for every type of wave.
 * This header enables Unity to right click and create an asset of Type WaveConfig.
 * This class is a ScriptableObject child class, which means, it's not a GameObject
 */
[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    //Configuration parameters
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float spawnRandomFactor = 0.3f;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private float moveSpeed = 10f;

    public GameObject GetEnemyPrefab() {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints() {
        var waveWaypoints = new List<Transform>();
        foreach (Transform waypointChild in pathPrefab.transform) {
            waveWaypoints.Add(waypointChild);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor() {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies() {
        return numberOfEnemies;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }
}
