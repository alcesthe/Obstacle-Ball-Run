using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Text timePassText;
    private void Awake()
    {
        // Pause Button
        transform.Find("Pause Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            GameManager.instance.PauseGame();
            pausePanel.SetActive(true);
        });
    }

    public void SetTextTimePassText(string time)
    {
        timePassText.text = "Time Pass: " + time;
    }

}
