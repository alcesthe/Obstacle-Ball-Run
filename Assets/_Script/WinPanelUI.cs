using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelUI : MonoBehaviour
{
    [SerializeField] Sprite starVisible;
    [SerializeField] Sprite starInvisible;
    [SerializeField] GameObject stars;

    private void Awake()
    {
        // Next Button
        transform.Find("Next Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            GameManager.instance.ResumeGame();
            Loader.LoadNextScene();
        });

        // Main Menu Button
        transform.Find("SelectLevel Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            GameManager.instance.ResumeGame();
            Loader.Load(Loader.Scene.SelectLevel);
        });
    }

    private void Update()
    {
        int starRate = GameManager.instance.starRate;
        int i = 1; // Start from one to three star
        foreach (Transform star in stars.transform)
        {
            star.GetComponent<Image>().sprite = starVisible;

            i++;
            if (i > starRate){ break; }
        }
    }

}
