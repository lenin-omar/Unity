using UnityEngine;
using System.Collections;

//Clase Singleton en C#
public class MusicPlayer : MonoBehaviour {

	static MusicPlayer playerInstance = null;

	void Awake() {
		if (playerInstance == null) {
			playerInstance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			/* A diferencia de java, el objeto gameObject siempre se crea al llamar a esta clase, 
			 * asi que se debe destruir cada nuevo gameObject para usar solo el playerInstance creado desde el inicio del juego.
			 */
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
