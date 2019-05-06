using UnityEngine;

public class Ball : MonoBehaviour {

    //Configuration parameters
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] private float xVelocity = 5f;
    [SerializeField] private float yVelocity = 13f;
    [SerializeField] float randomFactor = 0.2f;

    //State
    Vector2 delta;
    private bool hasStarted = false;

    //Cached reference
    AudioSource audioSource;
    Rigidbody2D rigidB2D;

    // Use this for initialization
    void Start() {
        //delta es la posicion actual de la bola menos la posición del paddle
        //transform pertenece a la bola
        delta = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidB2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update() {
        if (!hasStarted) {
            LockToPaddle();
            LaunchBall();
        }
    }

    private void LockToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + delta;
    }

    private void LaunchBall() {
        if (Input.GetMouseButtonDown(0)) {  //Si se da click izquierdo al mouse
            //Se obtiene el RigidBody de la bola y su velocidad
            //Se obtiene de esa manera (GetComponent) y no directamente (como transform) porque
            //todos los GameObjects tienen transform por default pero no todos los GO tienen RigidBody por default
            rigidB2D.velocity = new Vector2(xVelocity, yVelocity);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //velocityTweek is to avoid falling in a bouncing loop
        Vector2 velocityTweek = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted) {
            AudioClip clip;
            if (collision.gameObject.name.Contains("Wall")) {
                clip = ballSounds[0];
            } else {
                clip = ballSounds[1];
            }
            //Play the sound wothout interruption even if another sound is starting to play (so they could overlap)
            audioSource.PlayOneShot(clip);
            rigidB2D.velocity += velocityTweek;
        }
    }
}
