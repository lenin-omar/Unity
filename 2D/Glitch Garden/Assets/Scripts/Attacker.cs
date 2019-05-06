using UnityEngine;

public class Attacker : MonoBehaviour {

    float currentSpeed = 1f;
    GameObject currentTarget;
    Animator animator;
    LevelController levelController;

    private void Awake() {
        levelController = FindObjectOfType<LevelController>();
        levelController.AttackerSpawned();
    }

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if (!currentTarget) {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) {   //if currentTarget is NOT null
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }
    }

    private void OnDestroy() {
        if (levelController) {
            levelController.AttackerKilled();
        }
    }

}
