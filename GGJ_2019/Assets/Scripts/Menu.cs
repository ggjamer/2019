using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.LightweightPipeline;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{


    public Button continueButton;
    public Button saveButton;
    public Button quitButton;
    
    void Start()
    {
        continueButton.onClick.AddListener(delegate() { Continue();});
        saveButton.onClick.AddListener(delegate() { Save();});
        quitButton.onClick.AddListener(delegate() { Quit();});
    }
   
    public void StartGame(string level)
    {
        EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
    }
    
    public void Continue(){
    }
    
    public void Save(){
    
    }
    
    public void Quit(){
    
    }
}
