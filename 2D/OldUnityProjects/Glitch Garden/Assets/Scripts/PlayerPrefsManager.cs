﻿using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULT_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	//Master volume

	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	//Difficulty

	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULT_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range");
		}
	}
	
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULT_KEY);
	}

	//Level

	public static void UnlockLevel (int level) {
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("Not existing level");
		}
	}
	
	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY);
		bool isLevelUnlocked = (levelValue == 1);
		if (level <= Application.levelCount - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError("Not existing level");
			return false;
		}
	}

}
