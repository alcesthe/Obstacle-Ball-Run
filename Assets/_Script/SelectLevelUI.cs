using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelUI : MonoBehaviour
{
    private bool isEndLevel = false;
    private void Awake()
    {
        // Back To Home Button
        transform.Find("Back Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            Loader.Load(Loader.Scene.Start);
        });

        // Levels Button
        int level = 1; // start from level 1
        string buttonName; // The enum Scene name, Button name, Loader.Scene name must be match the name. Because this use string reference
        while (!isEndLevel)
        {
            buttonName = "Level_" + level.ToString();
            var button = transform.Find("Level Grid/" + buttonName);
            if (button)
            {
                string sceneName = buttonName; // Need time to AddListener, when use 1 variable (not buttonName and sceneName) can cause messed up because text change each iteration
                button.GetComponent<Button>().onClick.AddListener(delegate
                {
                    Loader.Load((Loader.Scene)Enum.Parse(typeof(Loader.Scene), sceneName));
                });
                button.GetComponent<Button>().interactable = PlayerPrefManager.IsLevelUnlocked(level);

                level += 1;
            } else
            {
                isEndLevel = true;
            }
        } 
    }

}
