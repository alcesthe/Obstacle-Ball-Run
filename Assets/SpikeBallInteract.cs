using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallInteract : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().Dead();
        }
    }
}
