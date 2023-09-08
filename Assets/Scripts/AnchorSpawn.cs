using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSpawn : MonoBehaviour
{

    [SerializeField] private GameObject AnchorToSpawn;
    void Start()
    {
        Instantiate(AnchorToSpawn, gameObject.transform);
    }
}
