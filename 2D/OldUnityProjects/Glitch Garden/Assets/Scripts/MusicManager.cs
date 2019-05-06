using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] audioMusicChangeArray;

	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad (gameObject);
	}

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}
	
	void OnLevelWasLoaded(int level) {
		if (audioMusicChangeArray[level]) {	//Si existe un AudioClip en el arreglo
			audioSource.clip = audioMusicChangeArray[level];
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume(float volume) {
		audioSource.volume = volume;
	}
}
