using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour, Interactible {
    public ActorTypes actorType;
    
    // All dialogues of this npc
    // The array position is indicised by the Game State
    public DialogueObject[] dialogues;

    public bool IsInteractible() {
        return false;
    }

    public void Dialogue() {
        int idx = (int) GameLogic.Instance.GameState;
    }
}
