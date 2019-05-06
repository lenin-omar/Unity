using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed = 2f;
    [SerializeField] float damage = 50f;

    //float rotation = -180f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //rotation += transform.rotation.z;
        //transform.Rotate(0, 0, rotation * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (health && attacker) {   //if attacker and health are not null
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
