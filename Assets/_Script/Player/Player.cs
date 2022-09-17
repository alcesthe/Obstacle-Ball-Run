using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float depthToReset = 10.0f; // When player reach below this point of Y axis, reset player to start point
    private GameObject terrain;
    private Vector3 startPoint;
    void Start()
    {
        startPoint = transform.position;
        terrain = GameObject.FindGameObjectWithTag("Terrain");
    }

    // Update is called once per frame
    void Update()
    {
        KeepPlayerInTerrain();
        CheckIsDropInHole();
    }

    private void CheckIsDropInHole()
    {
        if (transform.position.y <= depthToReset)
        {
            Debug.Log("Work");
            transform.position = startPoint;
        }
    }

    public Vector3 GetStartPoint()
    {
        return startPoint;
    }

    private void KeepPlayerInTerrain()
    {
        TerrainCollider terrainCollider = terrain.GetComponent<TerrainCollider>();
        Vector3 terrainBoundary = terrainCollider.bounds.size;

        if ((terrainBoundary.x < transform.position.x || transform.position.x < 0) || (terrainBoundary.z < transform.position.z || transform.position.z < 0))
        {
            float clampX = Mathf.Clamp(transform.position.x, 0, terrainBoundary.x);
            float clampZ = Mathf.Clamp(transform.position.z, 0, terrainBoundary.z);

            transform.position = new Vector3(clampX, transform.position.y, clampZ);
        }
    }
}
