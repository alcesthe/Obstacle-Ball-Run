using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float panSpeed = 0.1f;
    [SerializeField] float smoothSpeed = 10f;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int inverted;
        if (PlayerPrefManager.GetInvertView())
        {
            inverted = -1;
        }
        else
        {
            inverted = 1;
        }

        offset.x = Mathf.Clamp(offset.x + (CrossPlatformInputManager.GetAxis("RHoriz") * panSpeed * inverted), -10, 10);
        offset.y = Mathf.Clamp(offset.y + (CrossPlatformInputManager.GetAxis("RVert") * panSpeed * inverted), 0, 10);

        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1);
        transform.position = smoothedPosition;


        transform.LookAt(player.transform);
    }
}
