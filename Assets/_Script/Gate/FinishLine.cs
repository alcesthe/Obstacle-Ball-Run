using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // LevelLoader or Canvas.cs will handle the pause game
            Debug.Log("ADD CONGRAT MENU");
        }
    }

}
