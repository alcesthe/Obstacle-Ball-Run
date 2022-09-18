using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    private float volume;
    private bool isInvert;

    private Slider volumeSlider;
    private Toggle invertToggle;

    private void Awake()
    {
        volumeSlider = transform.Find("Volume/Volume Slider").GetComponent<Slider>();
        invertToggle = transform.Find("Invert View Axis/Invert Toggle").GetComponent<Toggle>();

        // Apply Button
        transform.Find("Buttons/Apply Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            int invertIntValue;
            PlayerPrefManager.SetMasterVolume(volume);

            // Transform bool to int because PlayerPref don't have bool
            if (isInvert){invertIntValue = 1;} else {invertIntValue = 0;}

            PlayerPrefManager.SetInvertView(invertIntValue);
            Loader.Load(Loader.Scene.Start);
        });

        // Option Button
        transform.Find("Buttons/Cancel Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            Loader.Load(Loader.Scene.Start);
        });

        // Reset Button
        transform.Find("Reset Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            PlayerPrefManager.ResetAllPreferences();
        });
    }

    private void Start()
    {
        volumeSlider.value = PlayerPrefManager.GetMasterVolume();
        invertToggle.isOn = PlayerPrefManager.GetInvertView();
    }

    private void Update()
    {
        volume = volumeSlider.value;
        isInvert = invertToggle.isOn;
    }
}
