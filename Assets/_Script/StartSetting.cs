using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1366, 768, true);

        if(PlayerPrefs.GetInt(PlayerPrefManager.FIRST_TIME_OPEN_KEY, 1) == 1)
        {
            PlayerPrefManager.SetMasterVolume(0.5f);
            PlayerPrefManager.SetInvertView(1);

            PlayerPrefs.SetInt(PlayerPrefManager.FIRST_TIME_OPEN_KEY, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
