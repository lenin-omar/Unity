using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

}
