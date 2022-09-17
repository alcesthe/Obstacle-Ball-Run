using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour
{
    private const int BUFFER_FRAMES = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFER_FRAMES];
    private const float SMOOTH_SPEED = 0.125f;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
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
        //transform.position = keyFrames[frame].pos;
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
