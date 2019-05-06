using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int coinPoints = 100;

    GameSession gameSession;

    private void Start() {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
        gameSession.addScore(coinPoints);
        Destroy(gameObject);
    }
}
