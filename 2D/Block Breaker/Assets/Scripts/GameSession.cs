using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour {

    //Configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 13;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoPlayEnabled;

    //State variables
    [SerializeField] int currentScore = 0;

    //A way to implement a singleton pattern
    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);    //gameObject is the current instance of GameStatus
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame() {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() {
        return autoPlayEnabled;
    }
}
