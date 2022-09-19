using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_new", menuName = "Level Information")]
public class LevelInformation : ScriptableObject
{
    // All using seconds
    public float totalTime = 180;
    public float windSpeed = 0;
    public float hammerSwingSpeed = 5;
    public float timeBetweenSpawnBall = 5;
}
