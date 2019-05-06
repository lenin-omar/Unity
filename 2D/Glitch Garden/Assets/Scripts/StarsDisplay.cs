using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour {

    [SerializeField] int stars = 100;
    Text starsText;

	// Use this for initialization
	void Start () {
        starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        starsText.text = stars.ToString();
    }

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount) {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int starCost) {
        return stars >= starCost;
    }

}
