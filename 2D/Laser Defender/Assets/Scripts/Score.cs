using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text scoreText;
    private GameSession gameSession;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
