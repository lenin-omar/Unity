using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBall;
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {
		/*
		 * Al cambiar de public a private la variable Paddle, esta ya no esta expuesta en unity inspector.
		 * Para no tener que arrastrar el game object en unity cada nueva scene/nivel, 
		 * podemos encontrar el objeto usando el metodo FindObjectOfType().
		 */
		paddle = GameObject.FindObjectOfType<Paddle> ();
		//Distancia entre el paddle y la bola. Siempre debe ser la misma si no se ha lanzado la bola aun, x eso se calcula una sola vez.
		paddleToBall = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//Nueva posicion de la bola. Como la distancia entre el paddle y la bola siempre es la misma, aqui solo se recalcula
			//la posicion X de la bola en base a la posicion X del paddle.
			this.transform.position = paddle.transform.position + paddleToBall;
			//Si se presiona el boton del mouse, se lanza la bola en linea recta.
			if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (hasStarted) {	//La bola colisiona con el padle al iniciar el juego, hasStarted verifica q la bola ya e haya lanzado
			GetComponent<AudioSource>().Play ();
		}
		GetComponent<Rigidbody2D>().velocity += tweak;
	}
}
