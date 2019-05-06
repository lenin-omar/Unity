using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    int max, min, guess;

	// Use this for initialization
	void Start () {
        StartGame();
	}

    void StartGame() {
        max = 1000;
        min = 1;
        guess = 500;
        Debug.Log("*** Welcome to Number Wizard ***");
        Debug.Log("Pick a number, don't tell me what it is");
        Debug.Log("Highest number you can pick is: " + max);
        Debug.Log("Lowest number you can pick is: " + min);
        Debug.Log("Tell me if your number is higher or lower than " + guess);
        Debug.Log("Up arrow = higher, Down arrow = lower, Enter = Correct!");
        max++;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            NextGuess();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess;
            NextGuess();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("I won!");
            StartGame();
        }
	}

    void NextGuess() {
        guess = (max + min) / 2;
        Debug.Log("Tell me if your number is higher or lower than " + guess);
    }
}
