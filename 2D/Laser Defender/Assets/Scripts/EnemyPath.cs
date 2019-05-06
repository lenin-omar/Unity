using System.Collections.Generic;
using UnityEngine;

//This script is a component in the Enemy prefab.
public class EnemyPath : MonoBehaviour {

    int waypointIdex = 0;
    WaveConfig waveConfig; //We need the WaveConfig in order to know the points the ship is going to follow 
    List<Transform> waypoints;

    // Use this for initialization
    void Start () {
        waypoints = waveConfig.GetWaypoints();
        //The enemy is going to be in the position of the 1st waypoint when game starts
        transform.position = waypoints[waypointIdex].position;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void Move() {
        if (waypointIdex <= waypoints.Count - 1) {
            var targetPosition = waypoints[waypointIdex].position;
            var movememntThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;    //independent frame rate
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movememntThisFrame);
            if (transform.position == targetPosition) {
                waypointIdex++;
            }
        } else {
            Destroy(gameObject);
        }
    }

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }
}
