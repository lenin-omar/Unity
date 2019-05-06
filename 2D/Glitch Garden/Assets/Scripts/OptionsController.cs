using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider dificultySlider;

    float volumeDefault = 0.5f;
    float difficultyDefault = 1f;

    MusicPlayer musicPlayer;

    // Use this for initialization
    void Start () {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        dificultySlider.value = PlayerPrefsController.GetDifficulty();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
		if (musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(dificultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults() {
        volumeSlider.value = volumeDefault;
        dificultySlider.value = difficultyDefault;
    }
}
