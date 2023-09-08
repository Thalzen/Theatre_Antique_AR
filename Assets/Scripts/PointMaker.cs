using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PointMaker : MonoBehaviour
{
#if UNITY_EDITOR
    private static int _counter; //nombre de point dans la scene
    private static GameObject _gos;

    [MenuItem("ARLocation/Create New Point")]
    static void PointMake()
    {
        _counter = 0;
        while (true)
        {
            _gos = GameObject.Find("Point" +_counter);
            if (!_gos)
            {
                break;
            }
            else
            {
                _counter++;
            }
        }

        GameObject go = Instantiate(Resources.Load<GameObject>("Prefab/Point"));
        go.transform.position = new Vector3(go.transform.position.x, 1.5f, go.transform.position.z);
        go.name = "Point" + _counter;

    }
#endif
}
