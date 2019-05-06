using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    //Configuration
    [SerializeField] Attacker[] attackersPrefab;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    bool spawn = true;

    // Use this for initialization
    IEnumerator Start () {
		while(spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker() {
        var attackerIndex = Random.Range(0, attackersPrefab.Length);
        Spawn(attackersPrefab[attackerIndex]);
    }

    private void Spawn(Attacker attacker) {
        //A new attacker is created
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation);
        //Makes this new instance a child of the spawner.
        //Assigns the value of current transform (spawner) as the newAttacker parent transform.
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning() {
        spawn = false;
    }

}
