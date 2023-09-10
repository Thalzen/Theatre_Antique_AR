using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraRaycast : MonoBehaviour
{
  
    [SerializeField] private Image _cameraFocus;
    [SerializeField] private TextMeshProUGUI infoBarText;
    [SerializeField] private GameObject _infoButton;
    [SerializeField] private Camera _camera;
    [SerializeField] private AppData _appData;
  //  public GameObject[] prefabArray;
    [SerializeField] private string[] englishPrefabNameArray;
    [SerializeField] private string[] frenchPrefabNameArray;
    [SerializeField] private GameObject[] englishdescription;
    [SerializeField] private GameObject[] frenchdescription;
    private int currentselected;
    private bool _isSelected;
    private bool _isPointing;
    private bool _toggle;

    [SerializeField] private GameObject frenchCurtainButton;
    [SerializeField] private GameObject englishCurtainButton;
  
    
    public void closedescription()
    {
        _isSelected = false;
        _toggle = false;
    }
    
    void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit);
        
        // Debug.DrawLine(_camera.transform.position,hit.point,Color.red);
        if (hit.collider )
        {
            if (hit.collider.CompareTag("2"))
            {
                if (_appData.currentLanguage == "French")
                {
                    frenchCurtainButton.SetActive(true);  
                }
                else if (_appData.currentLanguage == "English")
                {
                    englishCurtainButton.SetActive(true);
                }
            }
            

            int x = int.Parse(hit.collider.gameObject.tag);
            currentselected = x;
            if (_appData.currentLanguage == "French" )
            {
                if (hit.collider.CompareTag("2") == false)
                {
                    frenchCurtainButton.SetActive(false);
                    englishCurtainButton.SetActive(false);
                }
                _cameraFocus.color = Color.white;
                infoBarText.GetComponent<TextMeshProUGUI>().text = frenchPrefabNameArray[x];
                _infoButton.GetComponent<Button>().interactable = true;
                _isPointing = true;
            }
            else if (_appData.currentLanguage == "English" )
            {
                if (hit.collider.CompareTag("2") == false)
                {
                    frenchCurtainButton.SetActive(false);
                    englishCurtainButton.SetActive(false);
                }
                _cameraFocus.color = Color.white;
                infoBarText.GetComponent<TextMeshProUGUI>().text = englishPrefabNameArray[x];
                _infoButton.GetComponent<Button>().interactable = true;
                _isPointing = true;
            }
        }
        else 
        {
            
            frenchCurtainButton.SetActive(false);
            englishCurtainButton.SetActive(false);
                _cameraFocus.color = Color.gray;
            infoBarText.GetComponent<TextMeshProUGUI>().text  = "";
            _isPointing = false;
            if (_isSelected == false)
            { 
                _infoButton.GetComponent<Button>().interactable = false;
            }

        }
        
      
    }

    public void InfoButton()
    {
        if (_toggle == false)
        {
            if (_isSelected)
            {
                _isSelected = false;
            }
        
            if (_isPointing && _appData.currentLanguage == "French")
            {
                foreach (var gameobject in frenchdescription)
                {
                    gameobject.SetActive(false);
                }
                frenchdescription[currentselected].SetActive(true);
                _isSelected = true;
            }
            
            else if (_isPointing && _appData.currentLanguage == "English")
            {
                foreach (var gameobject in englishdescription)
                {
                    gameobject.SetActive(false);
                }
                englishdescription[currentselected].SetActive(true);
                _isSelected = true;
            }

            _toggle = true;
        }
        else
        {
            _toggle = false;
            _isSelected = false;
            foreach (var gameobject in frenchdescription )
            {
                gameobject.SetActive(false);
            }
            foreach (var gameobject in englishdescription)
            {
                gameobject.SetActive(false);
            }
        }
       
        
    }
    
    
    //Legende Tag
    // 0 == Pilier Corinthien
    // 1 == 

}


    
      

   

