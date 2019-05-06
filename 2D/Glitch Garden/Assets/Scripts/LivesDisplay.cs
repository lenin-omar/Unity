using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {

    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;

    float lives;
    Text livesText;

    // Use this for initialization
    void Start () {
        //Next line rests the level from the base lives, so, if level it's EASY (0) 3 base lives - 0 = 3
        //if level it's MEDIUM (1) 3 base lives - 1 = 2 and 
        //if level it's HARD (2) 3 base lives - 2 = 1
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        /* TODO: Create a Difficulty controller class to modify:
         * Base lives
         * Speed of attackers spawners
         * Speed of attackers
         * Number of attackers (Fox, Lizzard, etc)       
         * Health of attackers
         * Health of defenders
         * Level duration
         * 
         * That way previous line would look like:
         * difficultyController.GetBaseLives();
         */
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        if (lives <= 0) {
            lives = 0;
        }
        livesText.text = lives.ToString();
    }

    public void DecreaseLives() {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0) {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
