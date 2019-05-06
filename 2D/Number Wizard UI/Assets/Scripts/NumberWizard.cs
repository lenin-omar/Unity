using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour {

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;

	// Use this for initialization
	void Start () {
        NextGuess();
	}

    public void OnPressHigher() {
        if (guess < 1000) {
            min = guess + 1;
            NextGuess();
        }
    }

    public void OnPressLower() {
        if (guess > 1) {
            max = guess - 1;
            NextGuess();
        }
    }

    void NextGuess() {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

}
