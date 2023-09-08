using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPage : MonoBehaviour



{
    public int maxPages = 2;
    public GameObject[] pages;
   public int index;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject confirmTutoButton;

    void Start()
    {
        index = 0;
    }
        

    void Update()
    {
        if (index >= maxPages)
        {
            index = maxPages;
            nextButton.GetComponent<Button>().interactable = false;
            if (confirmTutoButton != null)
            {
                confirmTutoButton.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            nextButton.GetComponent<Button>().interactable = true;
        }


        if (index < maxPages)
        {
            if (confirmTutoButton != null)
            {
                confirmTutoButton.GetComponent<Button>().interactable = false;
            }
        }

        
        
        
        if (index <= 0)
        {
            index = 0;
           previousButton.GetComponent<Button>().interactable = false;
           
           
           
           
        }
        else
        {
            previousButton.GetComponent<Button>().interactable = true;
        }
        


        if(index == 0)
        {
            pages[0].gameObject.SetActive(true);
        }
        
    }

    public void Next()
    {


        index += 1;
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].gameObject.SetActive(false);
            pages[index].gameObject.SetActive(true);
        }
        //Debug.Log(index);
    }
    
    
    public void Previous()
    {
        index -= 1;
    
            for(int i = 0 ; i < pages.Length; i++)
            {
                pages[i].gameObject.SetActive(false);
                pages[index].gameObject.SetActive(true);
            }
           // Debug.Log(index);
    }
       

   
}