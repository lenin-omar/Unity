using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Level timer in seconds")] [SerializeField] float levelTime = 10;
    bool timeFinished = false;

    // Update is called once per frame
    void Update () {
        if (!timeFinished) {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
            timeFinished = Time.timeSinceLevelLoad >= levelTime;
            if (timeFinished) {
                FindObjectOfType<LevelController>().LevelTimerFinish(timeFinished);
            }
        }
    }
}
