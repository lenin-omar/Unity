using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner laneAttackerSpawner;
    Animator animator;

    // Use this for initialization
    void Start () {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner attackerSpawner in attackerSpawners) {
            //Substract shooter Y position (which is current Y position and also defender shooter Y position)
            //from attackerSpawner Y position. If the substraction is almost 0 (Mathf.Epsilon),
            //attacker spawner is on the same lane.
            var deltaYposition = attackerSpawner.transform.position.y - transform.position.y;
            bool isLaneAttackerSpawner = deltaYposition <= 0.3f && deltaYposition >= Mathf.Epsilon;
            if (isLaneAttackerSpawner) {
                laneAttackerSpawner = attackerSpawner;
            }
        }
    }

    /*
        If laneAttackerSpawner has children it meann
        there are attacker in lane.      
    */
    private bool IsAttackerInLane() {
        return laneAttackerSpawner && laneAttackerSpawner.transform.childCount > 0;
    }

    public void Fire() {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
