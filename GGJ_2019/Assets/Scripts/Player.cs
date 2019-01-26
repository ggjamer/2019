using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    private string _name;
    private Sprite _sprite;
    private PlayerMovement _movement;

    public void SetParams(string name, Sprite sprite) {
        _name = name;
        _sprite = sprite;
    }
    public void Init() {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = _sprite;
        _movement = this.gameObject.GetComponent<PlayerMovement>();
    }

    public void Interact(Interactible obj) {
        if (obj.IsInteractible()) {
            obj.Dialogue();
        }
    }
}
