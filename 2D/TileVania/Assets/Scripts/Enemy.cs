using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed = 1f;

    Rigidbody2D rigidBody;
    Animator animator;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x > 0) {   //if it's facing right. This is updated inside OnTriggerExit2D()
            rigidBody.velocity = new Vector2(speed, 0f);
        } else {
            rigidBody.velocity = new Vector2(-speed, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D groundCollider) {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidBody.velocity.x)), 1f);
    }
}
