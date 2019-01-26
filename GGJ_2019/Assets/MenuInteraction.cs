using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngineInternal.Input;

public class MenuInteraction : MonoBehaviour
{

    private List<SelectableText> selectableTexts = new List<SelectableText>();
    public int selectedElement = 0;
    public Color unfocussedColor;
    public Color focussedColor;
    public string[] defaultTexts;
    public float offset = 20;

    public GameObject TextPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var text in defaultTexts)
        {
            AddText(0, text);
        }
        
        ColorSelected(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("down")){
            SelectNextText(); 
            ColorSelected();
        }
        if(Input.GetKeyDown("up")){
            SelectPrevText(); 
            ColorSelected();
        }
        if(Input.GetButton("Jump"))
        {
            RunCurrentSelection();
        }
    }

    private void RunCurrentSelection()
    {
        if (selectableTexts.Count > selectedElement)
        {
            selectableTexts[selectedElement].callback.DynamicInvoke();
        }
    }

    public void AddText(int id, string text)
    {
        AddText(id, text, delegate() { });
    }

    public void AddText(int id, string text, Action callback)
    {
        
        GameObject gameObject = Instantiate(TextPrefab,transform);
        gameObject.transform.localPosition = new Vector3(0, 0 - offset * selectableTexts.Count, 1);
        gameObject.GetComponent<Text>().text = text;
        SelectableText selectableText = new SelectableText();
        selectableText.id = id;
        selectableText.text = text;
        selectableText.callback = callback;
        selectableText.gameObject = gameObject;

        this.selectableTexts.Add(selectableText);   
    }

    void SelectNextText()
    {
        selectedElement = (selectedElement+1) % selectableTexts.Count;
    }
    
    void SelectPrevText()
    {
        selectedElement = (selectedElement+selectableTexts.Count-1) % selectableTexts.Count;
    }

    void ColorSelected()
    {
        foreach (var selectableText in selectableTexts)
        {
            selectableText.gameObject.GetComponent<Text>().color = unfocussedColor;
        }

        if (selectableTexts.Count > selectedElement)
        {
            selectableTexts[selectedElement].gameObject.GetComponent<Text>().color = focussedColor;
        }


    }
}
