using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class QRCodeScan : MonoBehaviour
{
    private ARTrackedImageManager m_trackedimagemanager;

   [SerializeField] private Animator checkmarkanimator;
   [SerializeField] private GameObject Loadingdot;

   private void Awake()
   {
       m_trackedimagemanager = GetComponent<ARTrackedImageManager>();
   }

   private void OnEnable()
    {
        m_trackedimagemanager.trackedImagesChanged += ScannedQRcode;
    }

    private void OnDisable()
    {
        m_trackedimagemanager.trackedImagesChanged -= ScannedQRcode;
    }

    private void ScannedQRcode(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var updatedImage in eventArgs.updated)
        {
            StartCoroutine(QRcodeScannedStart());
        }
        

    }

    private IEnumerator QRcodeScannedStart()
    {
        
        Loadingdot.SetActive(false);
        checkmarkanimator.SetTrigger("Check");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("PointToTheater");
        
    }
}
