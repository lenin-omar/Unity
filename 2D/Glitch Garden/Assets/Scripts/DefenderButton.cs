using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {

    [SerializeField] Color32 defaultColor;
    [SerializeField] Defender defenderPrefab;

    DefenderSpawner defenderSpawner;
    Text costText;

    // Use this for initialization
    void Start () {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetStarCost().ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        var defenderButtons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton defenderButton in defenderButtons) {
            defenderButton.GetComponent<SpriteRenderer>().color = defaultColor;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}
