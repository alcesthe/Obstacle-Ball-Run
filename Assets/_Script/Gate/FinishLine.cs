using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int nextLevelNumber = int.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value) + 1;
            GameManager.instance.PauseGame();
            winPanel.SetActive(true);
            PlayerPrefManager.UnlockLevel("Level_" + nextLevelNumber);
        }
    }
}
