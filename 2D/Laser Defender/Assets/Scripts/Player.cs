using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    //Configuration parameters
    [Header("Player")]
    [SerializeField] private float health = 500f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float padding = .5f;   //Padding for the ship to avoid flying out of the screen
    [SerializeField] private GameObject deathVFX;

    [SerializeField] private float explosionDuration = 1f;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.50f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileFiringPeriod = .1f;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] [Range(0, 1)] private float laserSoundVolume = 0.50f;

    private Coroutine firingCoroutine;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update () {
        Move();
        Fire();
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move() {
        //Multiplying by Time.deltaTime allows game to be frame rate independent. 
        //X movement
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //Y movement
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
            //Alternatevely StopAllCoroutines() could be used but it'd stop all other coroutines
        }
    }

    //Coroutine to avoid pushing key for every projectile
    IEnumerator FireContinuously() {
        while(true) {
            //Creates a laser projectile in the position of the ship without rotation (Quaternion.identity)
            GameObject laserProjectile = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laserProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    /*
     * Parameter other is the collider, which could be a laser projectile, a bomb or
     * any other GO that can cause damage.
     */
    private void OnTriggerEnter2D(Collider2D other) {
        //Process hit
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null) {
            health -= damageDealer.GetDamage();
            damageDealer.Hit();
        }
        if (health <= 0) {
            health = 0;
            Die();
        }
    }

    public float GetHealth() {
        return health;
    }

    private void Die() {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }
}
