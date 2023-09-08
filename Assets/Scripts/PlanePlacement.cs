using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlanePlacement : MonoBehaviour
{
    private void Start()
    {
       

    }

    public void replace()
    {
        transform.position = new Vector3(transform.position.x, -1.75f, transform.position.z);
    }
}
