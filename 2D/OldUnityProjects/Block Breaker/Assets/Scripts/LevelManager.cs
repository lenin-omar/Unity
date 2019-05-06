﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		print ("Level loaded: "+name);
		Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}

	public void QuitRequest() {
		print ("I want to quit!");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
