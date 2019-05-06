using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class persis in the level only.
 * Its purpose is to remember which coins were already picked up
 * and not to generete them again if player dies.
 */
public class ScenePersist : MonoBehaviour {

    int startingSceneindex;

    private void Awake() {
        int numberOfScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if (numberOfScenePersist > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        startingSceneindex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
        //buildIndex will be different when next scene is loaded
		if (startingSceneindex != SceneManager.GetActiveScene().buildIndex) {
            Destroy(gameObject);
        }
    }
}
