using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class Replay : MonoBehaviour
{
    private const int BUFFER_FRAMES = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFER_FRAMES];
    private const float SMOOTH_SPEED = 0.125f;

    private Rigidbody rigidbody;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GetComponent<Player>();

        for (int i=0; i < BUFFER_FRAMES; i++)
        {
            keyFrames[i] = new MyKeyFrame(Time.time, player.startPoint, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            PlayBack();
        }
        else
        {
            Record();
        }
        
    }

    private void Record()
    {
        rigidbody.isKinematic = false;
        int frame = Time.frameCount % BUFFER_FRAMES;
        float time = Time.time;

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    private void PlayBack()
    {
        rigidbody.isKinematic = true;
        int frame = Time.frameCount % BUFFER_FRAMES;

        transform.position = Vector3.Lerp(transform.position, keyFrames[frame].pos, SMOOTH_SPEED);
        transform.rotation = keyFrames[frame].rot;
    }
}

/// <summary>
/// A structure to storing time, position and rotation
/// </summary>
public struct MyKeyFrame
{
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation)
    {
        time = aTime;
        pos = aPosition;
        rot = aRotation;
    }
}
