using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    void FixedUpdate()
    {
        float rotateSpeed = GameManager.instance.currentLevelInformation.hammerSwingSpeed;
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }
}
