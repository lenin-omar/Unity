using System;
using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int secondsToWait = 4;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    // Use this for initialization
    void Start() {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void AttackerSpawned() {
        numberOfAttackers ++;
    }

    public void AttackerKilled() {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(secondsToWait); //Wait until WaitForSeconds() finishes its execution
        FindObjectOfType<LevelLoader>().LoadNextScene();    //and runs LoadNextScene() after
    }

    public void HandleLoseCondition() {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinish(bool levelTimerFinished) {
        this.levelTimerFinished = levelTimerFinished;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner attackerSpawner in attackerSpawners) {
            attackerSpawner.StopSpawning();
        }
    }

}
