using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5.0f;
	public float padding = 0.5f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 250f;
	public AudioClip fireSound;

	float xmin;
	float xmax;

	// Use this for initialization
	void Start () {
		float distanceBetweenCameraAndPlayer = transform.position.z - Camera.main.transform.position.z;
		/*
		Pueden haber varias camaras en un solo juego, en el caso de este es solo una camara.
		La camara principal toma un Vector3 como parametro pero los valores X y Y 
		solo pueden ser 0 y 1 (0, 0) = izquierda, abajo; (1, 1) derecha, arriba.
		El valor Z del vector 3 de la camara principal es la posicion respecto a un objeto, 
		como este es un juego 2d, todos los objetos tienen la misma posicion Z 
		calculada en la primera linea de este metodo.
		*/
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distanceBetweenCameraAndPlayer));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distanceBetweenCameraAndPlayer));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}

	void Fire(){
		//startPosition era usada para que la nave no se destruyera al colisionar con su propio misil.
		//Ya no es necesario porque se agregaron capas pero no se ve bien que el misil surja desde el centro de la nave.
		Vector3 startPosition = transform.position + new Vector3 (0, 0.5f, 0); 
		GameObject laserShot = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		laserShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, startPosition);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			//Fire();	//Linea original
			//La siguiente linea llama al metodo varias veces cada X segundos hasta que la tecla se libera.
			//"Fire" es el nombre del metodo que se quiere ejecutar
			//0.0001f es el tiempo en segundos q va a pasar desde que presiona la tecla hasta que se ejecuta el metodo x primera vez
			//firingRate es el tiempo en segundos que va a pasar antes de que se ejecute de nuevo el metodo "Fire"
			InvokeRepeating("Fire", 0.00001f, firingRate);
		}

		if (Input.GetKeyUp(KeyCode.Space)) {
			//Detener ejecucion del metodo "Fire"
			CancelInvoke("Fire");
		}

		//Time.deltaTime es el tiempo que le toma al render de la imagen. Sirve para que el movimiento sea mas suave.
		if (Input.GetKey(KeyCode.LeftArrow)) {
			//transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;	//Hace lo mismo q l a linea anterior pero es mas entendible
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			//transform.position += new Vector3(+speed * Time.deltaTime, 0, 0);
			transform.position += Vector3.right * speed * Time.deltaTime;	//Hace lo mismo q l a linea anterior pero es mas entendible
		}
		//Restrict the player to the gamespace
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();	//Es el collider con el que chocamos, en este caso es el proyectil
		if (missile) {	//si el misil es null es xq la nave enemiga esta chocando con otro collider q no es el misil
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die ();
			}
		}
	}

	void Die() {
		//GameObject.Find ("LevelManager") obtiene el GameObject llamado LevelManager
		//el cual contiene un script llamado tambien LevelManager y se obtiene con .GetComponent<LevelManager> ()
		LevelManager manager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		manager.LoadLevel ("Win");
		Destroy(gameObject);	//Se destruye la nave del jugador
	}

}
