using UnityEngine;
using System.Collections;

//Clase Singleton en C#
public class MusicPlayer : MonoBehaviour {

	static MusicPlayer playerInstance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;

	void Awake() {
		if (playerInstance == null) {
			playerInstance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play ();
		} else {
			/* A diferencia de java, el objeto gameObject siempre se crea al llamar a esta clase, 
			 * asi que se debe destruir cada nuevo gameObject para usar solo el playerInstance creado desde el inicio del juego.
			 */
			Destroy (gameObject);
		}
	}

	void OnLevelWasLoaded(int level) {
		if (!music) {
			return;
		}
		music.Stop ();
		if (level == 0) {
			music.clip = startClip;
		}
		if (level == 1) {
			music.clip = gameClip;
		}
		if (level == 2) {
			music.clip = endClip;
		}
		music.loop = true;
		music.Play ();
	}
}
