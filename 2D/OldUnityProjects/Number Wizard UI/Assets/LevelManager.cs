using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		print ("Level load request for: "+name);
		Application.LoadLevel (name);
	}

	public void QuitRequest() {
		print ("I want to quit!");
		Application.Quit();
	}
}
