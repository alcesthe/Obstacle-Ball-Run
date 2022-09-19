using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerInteract : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.back * 30, ForceMode.Impulse);
        }
    }
}
