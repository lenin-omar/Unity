using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		//print ("Level loaded: "+name);
		Application.LoadLevel (name);
	}

	public void QuitRequest() {
		print ("Quit game");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
