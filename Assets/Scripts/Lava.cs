using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    Collider objectCollider;

    void Start()
    {
        objectCollider = GetComponent<Collider>();

        objectCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
