using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    void FixedUpdate()
    {
        float rotateSpeed = GameManager.instance.currentLevelInformation.axeSwingSpeed;
        transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
    }
}
