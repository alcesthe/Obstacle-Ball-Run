using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelUI : MonoBehaviour
{
    [SerializeField] Sprite starVisible;
    [SerializeField] Sprite starInvisible;
    [SerializeField] GameObject stars;
    [SerializeField] Text yourTimeText;

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
        SetStarUI();
    }

    private void SetStarUI()
    {
        int starRate = GameManager.instance.starRate;

        for (int i = 0; i < 3; i++)
        {
            if (i < starRate)
            {
                stars.transform.GetChild(i).GetComponent<Image>().sprite = starVisible;
            }
            else
            {
                stars.transform.GetChild(i).GetComponent<Image>().sprite = starInvisible;
            } 
        }
    }

    public void SetTextYourTimeUI(string time)
    {
        yourTimeText.text = "Your time: " + time;
    }

}
