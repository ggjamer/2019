using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.LightweightPipeline;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{


    public MenuInteraction menuInteraction;
   
    void Start()
    {
        menuInteraction.AddText(1, "Continue", Continue);
        menuInteraction.AddText(1, "Quit to Windows", Quit);
    }
   
    public void StartGame(string level)
    {
        
    }
    
    public void Continue()
    {
        SceneManager.LoadScene("tranquil_test");
    }
    
    public void Save(){
    
    }
    
    public void Quit(){
    
    }
}
