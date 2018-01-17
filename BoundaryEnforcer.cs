using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryEnforcer : MonoBehaviour
{
    float gravity = (float)-9.8;

    public Transform cameraRigTransform;
    bool colliding;

    Vector3 v_0;
    DateTime t_0;
    float height_at_impact;

    // Use this for initialization
    void Awake ()
    {
        colliding = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        colliding = true;
        height_at_impact = cameraRigTransform.transform.position.y;

        v_0 = -collision.relativeVelocity;
        t_0 = DateTime.Now;
    }

    void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    void Update()
    {
        float dt = (float) new TimeSpan(DateTime.Now.Ticks - t_0.Ticks).TotalSeconds;

        v_0.y += gravity * dt;
        t_0 = DateTime.Now;

        //translate camera rig by change in velocity over time
        cameraRigTransform.transform.position += v_0 * dt;

        //if we have hit the bottom, we stop moving
        if (cameraRigTransform.transform.position.y <= height_at_impact)
        {
            v_0 = Vector3.zero;
            //cameraRigTransform.transform = height_at_impact;
        }
    }
}
