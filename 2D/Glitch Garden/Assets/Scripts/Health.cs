using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVfx;

    public void DealDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            TriggerVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerVFX() {
        GameObject deathVfxObject;
        if (deathVfx) {
            deathVfxObject = Instantiate(deathVfx, transform.position, transform.rotation);
            Destroy(deathVfxObject, 1f);    //Destroys VFX after 1 second so effect can be seen and GO doesn't remain
        }
    }
}
