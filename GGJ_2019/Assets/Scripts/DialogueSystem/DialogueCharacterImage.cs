using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DialogueCharacterImage : MonoBehaviour
{
    public bool OpensTotTheLeft;
    
    public Image _image;

    private bool _characterShown;
	public bool FinaleActive = false;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ToggleCharacter(float duration = 1, Sprite characterImage = null)
    {
        if (characterImage != null) _image.sprite = characterImage;

		if(!FinaleActive)
			_image.rectTransform.DOAnchorPosX(_image.rectTransform.anchoredPosition.x + (_characterShown ^ OpensTotTheLeft ? -1 : 1) * _image.rectTransform.rect.width, duration);
        
        _characterShown = !_characterShown;
    }

}