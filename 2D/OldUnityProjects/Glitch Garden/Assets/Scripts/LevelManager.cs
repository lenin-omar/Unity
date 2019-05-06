using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float loadNextLevelAfter;

	void Start() {
		if (loadNextLevelAfter == 0) {
			Debug.Log("loadNextLevelAfter disabled");
		} else {
			Invoke ("LoadNextLevel", loadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		print ("Level loaded: "+name);
		Application.LoadLevel (name);
	}

	public void QuitRequest() {
		print ("I want to quit!");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
