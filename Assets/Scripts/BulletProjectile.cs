using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public float life = 0.3f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

}
