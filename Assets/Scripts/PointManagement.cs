using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointManagement : MonoBehaviour
{
    public GameObject ARCam;
    public GameObject Obj;
    private float dist;
    public float Range = 2;

    private void Awake()
    {
        Obj.SetActive(false);
        if (ARCam == null)
        {
            ARCam = GameObject.Find("AR Camera");
        }
    }

    private void FixedUpdate()
    {
        if (ARCam != null)
        {
            dist = Vector3.Distance(transform.position, ARCam.transform.position);

            if (dist < Range)
            {
                Obj.SetActive(true);
                print(gameObject.name + "Has been reached!");
            }
            
            if (dist > Range)
            {
                Obj.SetActive(false);
            }

        }
    }


#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up,Range);
        UnityEditor.Handles.Label(transform.position,gameObject.name+"\nRange ="+ Range);
    }
    #endif
}


