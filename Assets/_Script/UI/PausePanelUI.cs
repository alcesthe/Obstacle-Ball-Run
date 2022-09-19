using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelUI : MonoBehaviour
{
    private void Awake()
    {
        // Resume Button
        transform.Find("Resume Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            GameManager.instance.ResumeGame();
            gameObject.SetActive(false);
        });

        // Main Menu Button
        transform.Find("SelectLevel Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            GameManager.instance.ResumeGame();
            Loader.Load(Loader.Scene.SelectLevel);
        });
    }
}
