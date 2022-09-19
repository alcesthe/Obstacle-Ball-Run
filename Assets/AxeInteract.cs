using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeInteract : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().Dead();
        }
    }
}
