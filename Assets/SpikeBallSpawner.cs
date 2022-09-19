using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallSpawner : MonoBehaviour
{
    [SerializeField] float shotPower = 10;
    [SerializeField] GameObject spikeBall;
    void Start()
    {
        float repeatRate = GameManager.instance.currentLevelInformation.timeBetweenSpawnBall;
        Instantiate(spikeBall, transform.position, transform.rotation);
        InvokeRepeating("SpawnBall", repeatRate, 1.0f);
    }

    public void SpawnBall()
    {
        GameObject instance = Instantiate(spikeBall, transform.position, transform.rotation);
        instance.transform.Find("Interact").GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), 0, -shotPower), ForceMode.Impulse);
    }
}
