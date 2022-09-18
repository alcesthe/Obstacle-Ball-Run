using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPause = false;
    public int starRate = 0;
    private float fixedDeltaTime;
    public bool isFinish = false;

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
        fixedDeltaTime = Time.fixedDeltaTime;
    }
    // Update is called once per frame 
    void Update()
    {
        if (Input.GetButtonDown("Cancel")){
            TogglePauseGame();
        }

        if (!isFinish)
        {
            CountStar();
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

    private void OnApplicationPause(bool pause)
    {
        isPause = pause;
    }

    public void CountStar()
    {
        starRate = 3; // Count star Clamp(Rounded(Total time/ Use time))
    }
}

    

