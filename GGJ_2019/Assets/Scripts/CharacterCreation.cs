using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {

    public GameObject logicObj;
    public GameObject nameInputObj;
    public GameObject genderInputObj;
    private Text _nameInput;
    private Text _genderInput;
    public Sprite maleSprite;
    public Sprite femaleSprite;

    public Image preview;

    void Start() {
        _nameInput = nameInputObj.GetComponent<Text>();
        _genderInput = genderInputObj.GetComponent<Text>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_genderInput.text == "female") {
            preview.sprite = femaleSprite;
        } else if (_genderInput.text == "male") {
            preview.sprite = maleSprite;
        }
        else {
            preview.sprite = null;
        }
    }

    public void Submit() {
        if (_nameInput.text != null && _nameInput.text.Trim().Length != 0) {
            GameObject logicObj = Instantiate(this.logicObj);
            DontDestroyOnLoad(logicObj);
            GameLogic logic = logicObj.GetComponent<GameLogic>();
            logic.playerName = _nameInput.text;
            logic.playerSprite = preview.sprite;
        
            SceneManager.LoadScene(logic.initScene);
        }
    }
}
