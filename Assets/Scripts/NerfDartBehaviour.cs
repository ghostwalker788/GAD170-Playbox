﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aligns self to velocity, if speed is above a small tolerance. Purely visual niceity.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class NerfDartBehaviour : MonoBehaviour
{
    public GameObject Self;
    protected new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Invoke("Despawn", 20.0f);
    }

    private void LateUpdate()
    {
        //align to direction of travel if we are moving fast enough, small tolerance prevents jitter due to forcing a rotation on
        // an object with colliders that will then have new overlaps and be physic'ed apart
        if(rigidbody.velocity.sqrMagnitude > 0.5f)
            transform.rotation = Quaternion.LookRotation( rigidbody.velocity.normalized, Vector3.up);
    }
    private void Despawn()
    {
        Destroy(Self);
    }
}
