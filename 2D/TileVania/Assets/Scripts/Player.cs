using UnityEngine;

public class Player : MonoBehaviour {

    //Config
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 25f;
    [SerializeField] float climbingSpeed = 10f;
    [SerializeField] Vector2 deathVector = new Vector2(0f, 25f);

    //Chached component reference
    Rigidbody2D rigidBody;
    Animator animator;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeetCollider;
    float gravityAtStart;
    bool isAlive = true;
    GameSession gameSession;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        gravityAtStart = rigidBody.gravityScale;
        gameSession = FindObjectOfType<GameSession>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive) {
            Run();
            Jump();
            Climb();
            Die();
        }
    }

    private void Run() {
        var deltaX = Input.GetAxis("Horizontal");   //Value is between -1 and +1
        Vector2 playerVelocity = new Vector2(deltaX * runSpeed, rigidBody.velocity.y);
        rigidBody.velocity = playerVelocity;
        FlipSprite();
    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHasHorizontalSpeed);
        if (playerHasHorizontalSpeed) {
            //Mathf.Sign(rigidBody.velocity.x) gets the sign of the velocity in x axis (1 or -1)
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }

    private void Jump() {
        //collider.IsTouchingLayers(LayerMask.GetMask("Ground")) is used to know if the playeris touching layer "Ground"
        //and avoid to jump in the air
        if (Input.GetButtonDown("Jump") && playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rigidBody.velocity += jumpVelocity;
        }
    }

    private void Climb() {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
            var deltaY = Input.GetAxis("Vertical");   //Value is between -1 and +1
            Vector2 climbingVelocity = new Vector2(rigidBody.velocity.x, deltaY * climbingSpeed);
            rigidBody.velocity = climbingVelocity;
            rigidBody.gravityScale = 0f;
            //If players Y movement is bigger than 0 it means he's climbing
            animator.SetBool("isClimbing", Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon);
        } else {
            rigidBody.gravityScale = gravityAtStart;
            animator.SetBool("isClimbing", false);
        }
    }

    private void Die() {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards"))) {
            isAlive = false;
            animator.SetTrigger("die");
            rigidBody.velocity = deathVector;
            gameSession.ProcessPlayerDeath();
        }
    }
}
