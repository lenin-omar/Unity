using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int breakableCount;
	public Sprite[] hitSprites;	//Arreglo de sprites. Se ve en el inspector de Unity
	public GameObject smoke;

	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		maxHits = hitSprites.Length + 1;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	/*void OnCollisionEnter2D (Collision2D collision){
		//Destroy (this); //"this" is an instance of the class Brick. We want to destroy the game object, not the instance of the custom class we created
		//Destroy (gameObject);	//This line could be don in the method OnCollisionExit in case the ball passes through the brinck without breaking it
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}*/

	void OnCollisionExit2D (Collision2D collision) {
		if (isBreakable) {
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);	//sonido, posicion y volumen
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;
		if (timesHit >= maxHits) {	//Podriamos sobrepasar el limite de hits si existieran multiples bolas q golpearan los ladrillos al mismo tiempo
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke ();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void PuffSmoke () {
		//Se puede usar "as GameObject" al final de la linea siguiente en lugar del casteo (GameObject)
		GameObject smokePuff = (GameObject)Instantiate(smoke, transform.position, Quaternion.identity);	//Crea instancia del objeto smoke en la posicion del brick con rotacion 0
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
		/*
			smokePuff es un GameObject y gameObject es el ladrillo o brick en cuestion. ¿Se puede acceder a particleSystem.startColor
			por default desde smokePuff porque es es el unico componente que existe en ese GameObject?
			¿Se tiene q usar GetComponent<SpriteRenderer>().color desde el gameObject/brick porque tiene mas componentes en el inspector?
		 */
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;	//En el inspector de Unity, si se le pega una vez, mostrar sprite 0 (1 hit), si se le pega 2 mostrar sprite 1 (2 hit)
		if (hitSprites [spriteIndex] != null) {	//Valida que el sprite exista
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];	//Se obtiene el componente SpriteRenderer y se especifica el sprite a mostrar del arreglo.
		} else {
			Debug.LogError("Brick sprite missing!");
		}
	}

	//TODO: Delete once we can actually win
	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}
