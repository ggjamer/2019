using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour, Interactible {
    public ActorTypes actorType;
    public DialogueObject currentDialogue;
    public float activationDistance;

    void Update() {
        if (Vector3.Distance(GameLogic.Instance.player.transform.position, this.transform.position) < activationDistance
            && Input.GetButtonDown("Jump") && IsInteractible() && !GameLogic.Instance.dialogueActive) {
            Debug.Log("TRIGGERED");
            Dialogue();
        }
    }

    public bool IsInteractible() {
        return true;
    }

    public void Dialogue() {
        GameLogic.Instance.dialogueActive = true;
        GameObject dsObj = Instantiate(GameLogic.Instance.dialogueSystemObj);
        DialogueSystem ds = dsObj.GetComponent<DialogueSystem>();
        ds.StartDialogue(currentDialogue);
    }
}
