using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPause = false;
    private float fixedDeltaTime;

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
    }

    public void TogglePauseGame()
    {
        if (isPause = !isPause)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            Debug.Log("ADD PAUSE SCREEN");
        } else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        isPause = pause;
    }
}

    

