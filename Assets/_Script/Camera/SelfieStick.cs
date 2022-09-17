using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour
{
    public float panSpeed = 10f;

    private GameObject player;
    private Vector3 armRotation;
    private const float  SMOOTH_SPEED = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }

    // Using fixed update because the camera stick to the physic object
    void FixedUpdate()
    {
        armRotation.y += CrossPlatformInputManager.GetAxis("RHoriz") * panSpeed;
        armRotation.x += CrossPlatformInputManager.GetAxis("RVert") * panSpeed;

        //transform.position = Vector3.Lerp(transform.position, player.transform.position, SMOOTH_SPEED);
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
    }


}
