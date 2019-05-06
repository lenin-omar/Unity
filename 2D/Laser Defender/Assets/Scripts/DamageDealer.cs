using UnityEngine;

public class DamageDealer : MonoBehaviour {

    //Configuration parameters
    [SerializeField] private int damage = 100;

    public int GetDamage() {
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
    }
}
