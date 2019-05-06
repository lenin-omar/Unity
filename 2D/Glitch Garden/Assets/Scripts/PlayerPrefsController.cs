using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    public static void SetMasterVolume(float volume) {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
    }

    public static void SetDifficulty(float difficulty) {
        PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.5f);
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY, 1f);
    }
}
