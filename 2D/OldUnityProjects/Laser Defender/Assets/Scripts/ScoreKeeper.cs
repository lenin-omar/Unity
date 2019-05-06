using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	private Text scoreText;

	void Start() {
		//El GameObject "Score" es un Text que tiene ligado este script (ver inspector en Unity).
		//Con la siguiente linea se obtiene el componente "Text" para despues cambiar su valor.
		scoreText = GetComponent<Text>();
		Reset ();
	}

	public void Score(int points) {
		score += points;
		scoreText.text = score.ToString();
	}

	public static void Reset() {
		score = 0;
		//scoreText.text = score.ToString();
	}
}
