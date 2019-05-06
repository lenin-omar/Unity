using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*TODO: Do some tuning to create more levels
 * and change the difficulty/characters for every
 * more advance level in order to show level progression.
 */

public class LevelLoader : MonoBehaviour {

    int currentSceneindex;
    [SerializeField] int secondsToWait = 3;

    // Use this for initialization
    void Start () {
        currentSceneindex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("current scene: " + currentSceneindex);
        if (currentSceneindex == 0) {
            StartCoroutine(LoadStartScene());
        }
    }

    IEnumerator LoadStartScene() {
        yield return new WaitForSeconds(secondsToWait); //Wait until WaitForSeconds() finishes its execution
        LoadNextScene();    //and runs LoadNextScene() after
    }

    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Scene");
    }

    public void LoadOptionsMenu() {
        SceneManager.LoadScene("Options Scene");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneindex + 1);
    }

    public void RestartScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneindex);
    }

    public void LoadLoseScene() {
        SceneManager.LoadScene("Lose Scene");
    }

    public void QuitGame() {
        Application.Quit();
    }

}
