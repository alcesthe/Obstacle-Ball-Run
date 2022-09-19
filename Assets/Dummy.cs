using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.ResetGameManager(); // When change scene Reload game manager
    }
}
