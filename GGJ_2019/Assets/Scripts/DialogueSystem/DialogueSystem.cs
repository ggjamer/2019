﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public DialogueCharacterImage LeftCharacterImage, RightCharacterImage;
    public CanvasGroup TextCanvas;
    public Text SpeakerNameText, DialogueText;

    public float OpeningAnimationDuration = 1f;

    private int _currentLine;
    private string[] _dialogue;
    private bool _characterASpeaking;
    private string _characterAName, _characterBName;
    private Tweener _alphaTween;

    private bool pause;

    private void Start()
    {
        TextCanvas.alpha = 0;
    }

    private void Update()
    {
        if (_dialogue == null) return;


        if (!Input.GetButtonDown("Jump") || pause) return;
        if (_currentLine == -1)
        {
            Debug.Log("ending dialogue");

            TextCanvas.DOFade(0, OpeningAnimationDuration);
            
            GameLogic.Instance.dialogueActive = false;
            LeftCharacterImage.ToggleCharacter(OpeningAnimationDuration);
            RightCharacterImage.ToggleCharacter(OpeningAnimationDuration);

            _dialogue = null;
        }
        else
        {
            PlayNextLine();
            if (_currentLine >= _dialogue.Length)
            {
                Debug.Log("Dialogue ended");
                _currentLine = -1;
            }
        }
    }

    //public void StartDialogue(string characterA, string characterB, string[] dialogue)
    public void StartDialogue(DialogueObject diag)
	{
        Debug.Log("Starting dialogue");
        _dialogue = diag.diaglogue;
        _characterAName = diag.PersonA == "You" ? GameLogic.Instance.playerName : diag.PersonA;
        _characterBName = diag.PersonB == "You" ? GameLogic.Instance.playerName : diag.PersonB;
		RightCharacterImage._image.sprite = diag.PersonAImage == null ? GameLogic.Instance.playerSprite : diag.PersonAImage; // sorry luca
		LeftCharacterImage._image.sprite = diag.PersonBImage == null ? GameLogic.Instance.playerSprite : diag.PersonBImage; // sorry luca
		LeftCharacterImage.ToggleCharacter(OpeningAnimationDuration, GetPortraitForCharacter(diag.PersonA));
		RightCharacterImage.ToggleCharacter(OpeningAnimationDuration, GetPortraitForCharacter(diag.PersonB));

        TextCanvas.DOFade(1, OpeningAnimationDuration);

        _currentLine = 0;
        _characterASpeaking = true;
        PlayNextLine();
        
        // Actualize Game State
        /*if (diag.fireIndex) {
            GameLogic.Instance.dialogueIndex++;
        }

        if (diag.fireState) {
            GameLogic.Instance.NextGameState();
        }*/
    }

    private void PlayNextLine()
    {
        SpeakerNameText.text = _characterASpeaking ? _characterAName : _characterBName;

        StartCoroutine(PlayText(_dialogue[_currentLine]));
        _currentLine++;
        _characterASpeaking = !_characterASpeaking;
    }

    private IEnumerator PlayText(string text) {
        pause = true;
        DialogueText.text = "";
        foreach (char t in text)
        {
            yield return new WaitForSeconds(0.01f);
            DialogueText.text += t;
        }
        pause = false;
    }

    private Sprite GetPortraitForCharacter(string characterName)
    {
        return null;
    }

}