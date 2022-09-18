using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    private void Awake()
    {
        // Pause Button
        transform.Find("Pause Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            GameManager.instance.PauseGame();
            pausePanel.SetActive(true);
        });
    }

}
