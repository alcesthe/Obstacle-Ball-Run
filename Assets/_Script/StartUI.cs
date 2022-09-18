using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private void Awake()
    {
        // Start Button
        transform.Find("Start Button").GetComponent<Button>().onClick.AddListener(delegate 
        {
            Loader.LoadNextScene();
        });

        // Option Button
        transform.Find("Option Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            Loader.Load(Loader.Scene.Option);
        });

        // Exit Button
        transform.Find("Exit Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            Loader.LoadExit();
        });
    }
}
