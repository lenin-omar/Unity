using UnityEngine;

public class Enemy : MonoBehaviour {

    //Configuration parameters
    [Header("Enemy")]
    [SerializeField] private float health = 100f;
    [SerializeField] private int scoreValue = 100;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float explosionDuration = 1f;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] [Range(0,1)] private float deathSoundVolume = 0.75f;

    [Header("Projectile")]
    [SerializeField] private float minTimeBetweenShots = .3f;
    [SerializeField] private float maxTimeBetweenShots = .9f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] [Range(0, 1)] private float laserSoundVolume = 0.75f;

    private float shotCounter; //Time to be elepsed for the enemy projectile to be shot

    // Use this for initialization
    void Start () {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
	
	// Update is called once per frame
	void Update () {
        CountDownAndShoot();
    }

    private void CountDownAndShoot() {
        //shotCounter descreses based on the frame rate time
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0) {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);   //To avoid rain of projectiles
        }
    }

    private void Fire() {
        GameObject laserProjectile = Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, 180));
        laserProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, laserSoundVolume);
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
            Die();
        }
    }

    private void Die() {
        FindObjectOfType<GameSession>().AddScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }
}
