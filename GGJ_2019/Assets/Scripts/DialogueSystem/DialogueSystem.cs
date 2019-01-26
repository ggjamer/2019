using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
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

    private void Start()
    {
        TextCanvas.alpha = 0;
    }

    private void Update()
    {
        if (_dialogue == null) return;


        if (!Input.GetButtonDown("Action")) return;
        if (_currentLine == -1)
        {
            Debug.Log("ending dialogue");

            TextCanvas.DOFade(0, OpeningAnimationDuration);

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

    public void StartDialogue(string characterA, string characterB, string[] dialogue)
    {
        Debug.Log("Starting dialogue");
        _dialogue = dialogue;
        _characterAName = characterA;
        _characterBName = characterB;
        LeftCharacterImage.ToggleCharacter(OpeningAnimationDuration, GetPortraitForCharacter(characterA));
        RightCharacterImage.ToggleCharacter(OpeningAnimationDuration, GetPortraitForCharacter(characterB));

        TextCanvas.DOFade(1, OpeningAnimationDuration);

        _currentLine = 0;
        _characterASpeaking = true;
        PlayNextLine();
    }

    private void PlayNextLine()
    {
        SpeakerNameText.text = _characterASpeaking ? _characterAName : _characterBName;

        StartCoroutine(PlayText(_dialogue[_currentLine]));
        _currentLine++;
        _characterASpeaking = !_characterASpeaking;
    }

    private IEnumerator PlayText(string text)
    {
        DialogueText.text = "";
        foreach (char t in text)
        {
            yield return new WaitForSeconds(0.01f);
            DialogueText.text += t;
        }
    }

    private Sprite GetPortraitForCharacter(string characterName)
    {
        return null;
    }
}