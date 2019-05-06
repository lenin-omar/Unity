using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 10;
	private ScoreKeeper scoreKeeperInstance;
	public AudioClip fireSound;
	public AudioClip deathSound;

	void Start() {
		//Como el Game object Enemy se crea en runtime, es necesario obtener el "Text" de manera dinamica.
		//GameObject.Find("Score") es un metodo estatico que obtiene el GameObject de tipo Text llamado "Score".
		//A partir de ese Text llamado Score se obtiene su script, el cual se llama "ScoreKeeper" -> .GetComponent<ScoreKeeper>()
		scoreKeeperInstance = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}

	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void Fire() {
		//startPosition era usada para que los enemigos no se destruyeran al colisionar con sus propios misiles.
		//Ya no es necesario porque se agregaron capas pero no se ve bien que el misil surja desde el centro de la nave.
		Vector3 startPosition = transform.position + new Vector3 (0, -0.5f, 0);
		GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, startPosition);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();	//Es el collider con el que chocamos, en este caso es el proyectil
		if (missile) {	//si el misil es null es xq la nave enemiga esta chocando con otro collider q no es el misil
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}

	void Die() {
		AudioSource.PlayClipAtPoint (deathSound, transform.position);
		Destroy(gameObject);	//Se destruye la nave enemiga
		scoreKeeperInstance.Score(scoreValue);
	} 
}
