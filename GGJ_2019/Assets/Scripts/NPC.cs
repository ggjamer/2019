using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour, Interactible {
    public ActorTypes actorType;
    public DialogueObject currentDialogue;

    public bool IsInteractible() {
        return false;
    }

    public void Dialogue() {
        GameLogic.Instance.DialogueSystem.StartDialogue(currentDialogue);
    }
}
