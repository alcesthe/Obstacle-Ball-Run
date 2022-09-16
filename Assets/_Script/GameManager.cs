using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording;
    private bool isPause = false;
    private float fixedDeltaTime;

    private void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }
    // Update is called once per frame 
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetButtonDown("Cancel")){
            TogglePauseGame();
        }
    }

    private void TogglePauseGame()
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

    private void OnApplicationPause(bool pause)
    {
        isPause = pause;
    }
}

    

