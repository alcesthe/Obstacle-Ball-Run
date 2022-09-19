using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    TerrainCollider terrainCollider;

    private void Start()
    {
        terrainCollider = GetComponent<TerrainCollider>();
    }
}
