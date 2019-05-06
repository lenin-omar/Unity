using UnityEngine;

public class Fox : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Gravestone>()) {
            animator.SetTrigger("jumpTrigger");
        } else if (otherObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

}
