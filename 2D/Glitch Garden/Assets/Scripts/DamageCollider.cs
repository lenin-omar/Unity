using UnityEngine;

public class DamageCollider : MonoBehaviour {

    LivesDisplay livesDisplay;

    // Use this for initialization
    void Start () {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        livesDisplay.DecreaseLives();
        Destroy(otherCollider.gameObject);
    }
}
