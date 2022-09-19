using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPause = false;
    public int starRate = 0;
    public bool isFinish = false;
    public float timePassed;
    private float fixedDeltaTime;

    [Header("Scriptable Object")]
    [SerializeField] LevelInformation[] allLevelInformation;

    [HideInInspector] public LevelInformation currentLevelInformation;

    private LevelUI levelUI;
    private WinPanelUI winpaneUI;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime; // Store delta time for resume

        AssignLevelInformation();
        AssignUIText();
    }

    // Update is called once per frame 
    void Update()
    {
        Debug.Log("Total Time: " + currentLevelInformation.totalTime);
        StartCountingTime();
        // Input
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }

        CountStar();
    }


    private void AssignUIText()
    {
        levelUI = FindObjectOfType<LevelUI>();
        winpaneUI = FindObjectOfType<WinPanelUI>();
    }

    private void StartCountingTime()
    {
        timePassed += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(Mathf.RoundToInt(timePassed));

        if (levelUI)
        {
            levelUI.SetTextTimePassText(time.ToString(@"mm\:ss"));
        }

        if (winpaneUI)
        {
            winpaneUI.SetTextYourTimeUI(time.ToString(@"mm\:ss"));
        }
        else
        {
            AssignUIText();
        }
        
        //Debug.Log(time.ToString(@"mm\:ss")); //here backslash is must to tell that colon is
    }

    private void AssignLevelInformation()
    {
        // Assign LevelInformation (Scriptable Object). Get by name reference
        foreach (LevelInformation levelInformation in allLevelInformation)
        {
            if (levelInformation.name == SceneManager.GetActiveScene().name)
            {
                currentLevelInformation = levelInformation;
            }
        }
    }

    public void TogglePauseGame()
    {
        if (isPause = !isPause)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        } else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

/*    private void OnApplicationPause(bool pause) // Using for mobile device when out the app
    {
        isPause = pause;
    }*/

    public void CountStar()
    {
        if (currentLevelInformation != null)
        {
           starRate = Mathf.Clamp(Mathf.RoundToInt(currentLevelInformation.totalTime / timePassed), 1, 3); // Clamp value from 1 - 3 star
        }
    }

    public void ResetGameManager()
    {
        Debug.Log("Reseted !");
        timePassed = 0;
        AssignLevelInformation();
        AssignUIText();
    }
}

    

