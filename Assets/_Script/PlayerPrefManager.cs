using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerPrefManager
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    // const string LEVEL_KEY = "level_";
    const string INVERT_VIEW_KEY = "invert_view";


    public static void SetInvertView(int value)
    {
        PlayerPrefs.SetInt(INVERT_VIEW_KEY,value);
    }

    public static bool GetInvertView()
    {
        var isInvert = false;
        return isInvert = PlayerPrefs.GetInt(INVERT_VIEW_KEY) == 1 ? true : false;
    }

    public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("Master volume out of range !");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(string levelName)
    {
        PlayerPrefs.SetInt(levelName, 1);
    }

    public static bool IsLevelUnlocked(string levelName)
    {
        int levelValue = PlayerPrefs.GetInt(levelName);
        bool isLevelUnlocked = (levelValue == 1);

        return isLevelUnlocked;
    }

    public static void ResetAllPreferences()
    {
        PlayerPrefs.DeleteAll();

        // Default setting
        SetMasterVolume(0.5f);
        UnlockLevel("Level_1"); // Always open first level
    }
}
