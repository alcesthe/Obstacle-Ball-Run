using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour
{
    public float panSpeed = 10f;

    private GameObject player;
    private Vector3 armRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        armRotation.y += CrossPlatformInputManager.GetAxis("RHoriz") * panSpeed;
        armRotation.x += CrossPlatformInputManager.GetAxis("RVert") * panSpeed;

        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
    }
}
