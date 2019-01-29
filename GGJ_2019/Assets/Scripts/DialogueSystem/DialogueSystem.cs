using System.Collections;
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
	private DialogueObject _do;
	private bool _characterASpeaking;
	private string _characterAName, _characterBName;
	private Tweener _alphaTween;

	public Sprite Transparent;

	private bool pause;

	public bool finished = true;
	public bool finalDialogue = false;


	private void Start()
	{
		TextCanvas.alpha = 0;
	}

	private void Update()
	{
		if (_dialogue == null) return;


		if (!Input.GetButtonDown("Jump") || pause) return;
		if (_currentLine >= _dialogue.Length)
		{
			if(!finalDialogue)
			{
				StartCoroutine(TransparentSprite());
			}
			Debug.Log("ending dialogue");
			if (GameObject.Find("ReturnToMap") != null)
				GameObject.Find("ReturnToMap").GetComponent<ReturnToMap>().inDialogue = false;


			TextCanvas.DOFade(0, OpeningAnimationDuration);

			GameLogic.Instance.dialogueActive = false;
			LeftCharacterImage.ToggleCharacter(OpeningAnimationDuration);
			RightCharacterImage.ToggleCharacter(OpeningAnimationDuration);

			// Actualize Game State
			if (_do.fireIndex)
			{
				GameLogic.Instance.IncreaseDialogueIndex();
			}

			if (_do.fireState)
			{
				GameLogic.Instance.NextGameState();
			}

			_do = null;
			_dialogue = null;
			finished = true;
		}
		else
		{
			PlayNextLine();

		}
	}

	public void FinalDialogue()
	{
		LeftCharacterImage.FinaleActive = true;
		RightCharacterImage.FinaleActive = true;
		finalDialogue = true;

	}

	//public void StartDialogue(string characterA, string characterB, string[] dialogue)
	public void StartDialogue(DialogueObject diag)
	{
		if (GameObject.Find("ReturnToMap") != null)
			GameObject.Find("ReturnToMap").GetComponent<ReturnToMap>().inDialogue = true;

		Debug.Log("Starting dialogue");
		finished = false;
		_do = diag;
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
		pause = true;
		DialogueText.text = "";
		foreach (char t in text)
		{
			yield return new WaitForSeconds(0.01f);
			DialogueText.text += t;
		}
		pause = false;
	}

	private IEnumerator TransparentSprite()
	{
		yield return new WaitForSeconds(1.0f);
		LeftCharacterImage._image.sprite = Transparent;

	}

	private Sprite GetPortraitForCharacter(string characterName)
	{
		return null;
	}

}