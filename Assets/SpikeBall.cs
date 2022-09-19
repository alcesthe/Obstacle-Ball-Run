using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    [SerializeField] float aliveTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }
}
