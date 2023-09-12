using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AppData _appData;
    public bool isAppLeft;
    private bool _englishIsSelected;
    private bool _frenchIsSelected;
    [SerializeField] private GameObject englishButton;
    [SerializeField] private GameObject frenchButton;
    [SerializeField] private GameObject frenchMenu;
    [SerializeField] private GameObject englishMenu;
    [SerializeField] private Sprite englishButtonUnselected;
    [SerializeField] private Sprite englishButtonselected;
    [SerializeField] private Sprite frenchButtonUnselected;
    [SerializeField] private Sprite frenchButtonselected;
    [SerializeField] private GameObject popUpScanFrench;
    [SerializeField] private GameObject popUpScanEnglish;
    [SerializeField] private GameObject popUpPointerArFrench;
    [SerializeField] private GameObject popUpPointerArEnglish;

    [SerializeField] private GameObject OptionsTitle;
    [SerializeField] private GameObject MainMenuTitle;


    [SerializeField] private GameObject MainMenuButtonsFrench;
    [SerializeField] private GameObject OptionsButtonsFrench;

    [SerializeField] private GameObject MainMenuButtonsEnglish;
    [SerializeField] private GameObject OptionsButtonsEnglish;

    [SerializeField] private GameObject LoadingTextFrench;
    [SerializeField] private GameObject LoadingTextEnglish;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject ARsession;

    [SerializeField] private GameObject frenchIndications;
    [SerializeField] private GameObject EnglishIndications;

    [SerializeField] private GameObject frenchSliderOptions;
    [SerializeField] private GameObject EnglishSliderOptions;

    [SerializeField] private GameObject frenchTutorialPopUp;
    [SerializeField] private GameObject EnglishTutorialPopUp;

   


    void Start()
    {

        CheckLanguage();


        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() ==
            UnityEngine.SceneManagement.SceneManager.GetSceneByName("AR-Theatre") ||
            UnityEngine.SceneManagement.SceneManager.GetActiveScene() ==
            UnityEngine.SceneManagement.SceneManager.GetSceneByName("PointToTheater"))
        {

            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
        }

    }

    private void Awake()
    {
        Application.targetFrameRate = 30;

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {

            ARsession.GetComponent<ARSession>().Reset();
        }


    }


    public void LoadARScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("AR-Theatre");

    }

    public void LoadQRScane()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ScanTicket");
    }

    public void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

    }


    private void OnApplicationFocus(bool hasFocus)
    {
        isAppLeft = !hasFocus;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        isAppLeft = pauseStatus;
    }

    public void GoogleMAps()
    {
        StartCoroutine(OpenGoogleMaps());
    }

    IEnumerator OpenGoogleMaps()
    {
        Application.OpenURL("maps.app.goo.gl/U2wLYFbY9jbmTQA5A");
        yield return new WaitForSeconds(1f);
        if (isAppLeft)
        {
            isAppLeft = false;
        }
        else
        {
            Application.OpenURL("https://goo.gl/maps/4ewo5FMemEVb6EuaA");
        }
    }


    public void SelectEnglishLanguage()
    {
        _englishIsSelected = true;
        _frenchIsSelected = false;

        englishButton.GetComponent<Image>().sprite = englishButtonselected;
        frenchButton.GetComponent<Image>().sprite = frenchButtonUnselected;
    }

    public void SelectFrenchLanguage()
    {
        _englishIsSelected = false;
        _frenchIsSelected = true;

        frenchButton.GetComponent<Image>().sprite = frenchButtonselected;
        englishButton.GetComponent<Image>().sprite = englishButtonUnselected;
    }


    public void ConfirmLanguage()
    {
        if (_englishIsSelected)
        {
            _appData.currentLanguage = _appData.English;
            CheckLanguage();
            LoadMenuScene();


        }
        else if (_frenchIsSelected)
        {
            _appData.currentLanguage = _appData.French;
            CheckLanguage();
            LoadMenuScene();


        }
    }





    public void CheckLanguage()
    {
        if (frenchMenu && englishMenu != null)
        {
            if (_appData.currentLanguage == _appData.French)
            {
                frenchMenu.SetActive(true);
                englishMenu.SetActive(false);
            }
            else if (_appData.currentLanguage == _appData.English)
            {
                frenchMenu.SetActive(false);
                englishMenu.SetActive(true);
            }
        }

        if (popUpScanFrench && popUpScanEnglish != null)
        {
            if (_appData.currentLanguage == _appData.French)
            {
                popUpScanFrench.SetActive(true);
            }
            else if (_appData.currentLanguage == _appData.English)
            {
                popUpScanEnglish.SetActive(true);
            }
        }

        if (popUpPointerArFrench && popUpPointerArEnglish != null)
        {
            if (_appData.currentLanguage == _appData.French)
            {
                popUpPointerArFrench.SetActive(true);
            }
            else if (_appData.currentLanguage == _appData.English)
            {
                popUpPointerArEnglish.SetActive(true);
            }
        }

        if (LoadingTextFrench && LoadingTextEnglish != null)
        {
            if (_appData.currentLanguage == _appData.French)
            {
                LoadingTextFrench.SetActive(true);

            }
            else if (_appData.currentLanguage == _appData.English)
            {
                LoadingTextEnglish.SetActive(true);

            }
        }

        if (frenchIndications && EnglishIndications != null)
        {
            if (_appData.currentLanguage == _appData.French)
            {
                frenchIndications.SetActive(true);

            }
            else if (_appData.currentLanguage == _appData.English)
            {
                EnglishIndications.SetActive(true);

            }
        }

        if (frenchSliderOptions && EnglishSliderOptions != null)
        {
            if (_appData.currentLanguage == _appData.French)
            {
                frenchSliderOptions.SetActive(true);

            }
            else if (_appData.currentLanguage == _appData.English)
            {
                EnglishSliderOptions.SetActive(true);

            }
        }

        if (frenchTutorialPopUp && EnglishTutorialPopUp != null)
        {
            if (_appData.currentLanguage == _appData.French)
            {
                frenchTutorialPopUp.SetActive(true);

            }
            else if (_appData.currentLanguage == _appData.English)
            {
                EnglishTutorialPopUp.SetActive(true);

            }
        }
       
    }


    public void Loadingfinished()
    {
        LoadingScreen.SetActive(false);

    }



    public void ActiveOptionsButtons()
    {
        if (_appData.currentLanguage == _appData.French)
        {
            OptionsButtonsFrench.GetComponent<Animator>().SetBool("OptionsIn", true);
        }

        if (_appData.currentLanguage == _appData.English)
        {
            OptionsButtonsEnglish.GetComponent<Animator>().SetBool("OptionsIn", true);
        }

        OptionsTitle.GetComponent<Animator>().SetBool("OptionsTitle", true);

    }

    public void ActiveMenuButtons()
    {
        if (_appData.currentLanguage == _appData.French)
        {
            MainMenuButtonsFrench.GetComponent<Animator>().SetBool("MenuOut", false);
        }

        if (_appData.currentLanguage == _appData.English)
        {
            MainMenuButtonsEnglish.GetComponent<Animator>().SetBool("MenuOut", false);
        }

        MainMenuTitle.GetComponent<Animator>().SetBool("TitleMenu", true);

    }

    public void HideOptionsButtons()
    {

        if (_appData.currentLanguage == _appData.French)
        {
            OptionsButtonsFrench.GetComponent<Animator>().SetBool("OptionsIn", false);
        }

        if (_appData.currentLanguage == _appData.English)
        {
            OptionsButtonsEnglish.GetComponent<Animator>().SetBool("OptionsIn", false);
        }

        OptionsTitle.GetComponent<Animator>().SetBool("OptionsTitle", false);
    }

    public void HideMenuButtons()
    {
        if (_appData.currentLanguage == _appData.French)
        {
            MainMenuButtonsFrench.GetComponent<Animator>().SetBool("MenuOut", true);
        }

        if (_appData.currentLanguage == _appData.English)
        {
            MainMenuButtonsEnglish.GetComponent<Animator>().SetBool("MenuOut", true);
        }

        MainMenuTitle.GetComponent<Animator>().SetBool("TitleMenu", false);


    }



    public void QuitAppl()
    {
        Application.Quit();
    }

    public void LoadPointToTheater()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("PointToTheater");
    }

    public void HistoryButton()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        

    }





public void HistoryBackButton()
    {
        
        Screen.orientation = ScreenOrientation.Portrait;
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    public void ResetARsession()
    {
        ARsession.SetActive(false);
        ARsession.SetActive(true);
    }




}