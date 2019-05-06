using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetSelectedDefender(Defender selectedDefender) {
        defender = selectedDefender;
    }

    /*
    It's called when the  mouse is clicked.
    */
    private void OnMouseDown() {
        if (defender) {
            AttemptToPlaceDefenderAt();
        }
    }

    private void AttemptToPlaceDefenderAt() {
        var starsDisplay = FindObjectOfType<StarsDisplay>();
        int starCost = defender.GetStarCost();
        if (starsDisplay.HaveEnoughStars(starCost)) {
            Instantiate(defender, GetSquareClicked(), Quaternion.identity);
            starsDisplay.SpendStars(starCost);
        }
    }

    private Vector2 GetSquareClicked() {
        var clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 rawWorldPosition = Camera.main.ScreenToWorldPoint(clickPosition);   //This give us the square clicked
        return SnapToGrid(rawWorldPosition);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition) {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }
}
