using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioSource _backgroundmusic;
    private bool _audioIsMuted = false;
    [SerializeField] private Animator _volumeUiAnimator;
    //   [SerializeField] private Animator _zoomUiAnimator;
    [SerializeField] private Animator _focusCameraUiAnimator;
  //  [SerializeField] private GameObject _zoonButton;
    //[SerializeField] private Sprite _iconzoomplus;
   // [SerializeField] private Sprite _iconzoomminus;
    [SerializeField] private Animator curtainAnimator;
    private bool curtainIsOpen = false;
    [SerializeField] private GameObject curtainButton;
    
    
  
  

    public void OpenCurtain()
    {
        if (curtainIsOpen == false)
        {
            StartCoroutine(delayCurtainButton());
            curtainAnimator.SetBool("CurtainOn",true);
            curtainIsOpen = true;
            
        }
        else
        {
            StartCoroutine(delayCurtainButton());
            curtainAnimator.SetBool("CurtainOn",false);
            curtainIsOpen = false;
            
        }
        
    }



    IEnumerator delayCurtainButton()
    {
        curtainButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(1.5f);
        curtainButton.GetComponent<Button>().interactable = true;
    }
    
    public void MuteButton()
    {
        
        if (_audioIsMuted == false )
        {
            _volumeUiAnimator.SetBool("Mute",true);
            _audioIsMuted = true;
            _backgroundmusic.mute = true;
            
        }
        else
        {
            _volumeUiAnimator.SetBool("Mute",false);
            _audioIsMuted = false;
            _backgroundmusic.mute = false;
        }
        
    }
    
    IEnumerator MenuButtonDelay()
    {
        yield return new WaitForSeconds(0.27f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    
    
    
    // public void ZoomButton()
    // {
    //     if (_camera.fieldOfView >= 50)
    //     {
    //         _zoomUiAnimator.SetTrigger("ZoomIconAnim");
    //         _focusCameraUiAnimator.SetBool("ZoomAnim",true);
    //         _camera.fieldOfView = 30;
    //         _zoonButton.GetComponent<Image>().sprite = _iconzoomminus;
    //
    //     }
    //     else if (_camera.fieldOfView <50)
    //     {
    //         _zoomUiAnimator.SetTrigger("ZoomIconAnim");
    //         _focusCameraUiAnimator.SetBool("ZoomAnim",false);
    //         _camera.fieldOfView = 50;
    //         _zoonButton.GetComponent<Image>().sprite = _iconzoomplus;
    //       
    //     }
    //     
    // }
    
    
    
}
