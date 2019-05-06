using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger) {
		//print ("Trigger");
		/*
		 * Al cambiar de public a private la variable LevelManager, esta ya no esta expuesta en unity inspector.
		 * Para no tener que arrastrar el game object en unity cada nueva scene/nivel, 
		 * podemos encontrar el objeto usando el metodo FindObjectOfType().
		 */
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		levelManager.LoadLevel ("Lose");
	}

	void OnCollisionEnter2D (Collision2D collision){
		print ("Collision");
	}
}
