using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
    // Setup fields
    public string initScene;

    // Singleton variables
    private static GameLogic _instance;
    public static GameLogic Instance {
        get {
            return _instance;
        }
    }

    // Player Infos
    public GameObject playerObj;
    public GameObject player;
    public string playerName;
    public Sprite playerSprite;
    public RuntimeAnimatorController animatorController;
    private Player _playerBehaviour;
    public Vector3 PlayerPosition;
    
    //NPC Infos
    private GameObject[] activeNPCs;
    
    // Game State infos
    public GameState GameState;
    public StateInfo[] StateInfos;
    public Locations Location;
    private bool keysVisible = true;
    public bool playerVisible = true;
    
    // Camera Infos
    public Vector3 CameraPosition;
    public float Zoom;

    // Dialogue Handling
    public GameObject dialogueSystemObj;
    public DialogueObject[] newInTownDialogues;
    public DialogueObject[] scandalDialogues;
    public DialogueObject[] mayorsPermissionDialogues;
    public DialogueObject[] jailVisitDialogues;
    public DialogueObject[] toughballTalkDialogues;
    public DialogueObject[] coffeeBreakDialogues;
    public DialogueObject[] apologizeDialogues;
    public DialogueObject[] finaleDialogues;
    private DialogueObject[] sceneDialogues;
    public int dialogueIndex;
    public bool dialogueActive;
    
    void Awake() {
        _instance = this;
        SceneManager.sceneLoaded += init;
        GameState = GameState.NEW_IN_TOWN;
        dialogueIndex = 1;
    }

    void init(Scene scene, LoadSceneMode mode) {
        // Create Player
        if (playerVisible) {
            player = Instantiate(playerObj);
            _playerBehaviour = player.GetComponent<Player>();
            _playerBehaviour.SetParams(playerName, animatorController);
            _playerBehaviour.Init();
        }

        //Create NPCs
        activeNPCs = GameObject.FindGameObjectsWithTag("NPC");
        if (!keysVisible) {
            GameObject keys = Array.Find(activeNPCs, g => g.name == "Keys");
            if (keys != null) {
                keys.SetActive(false);
            }
        }

        sceneDialogues = newInTownDialogues;
        ActualizeDialogues();
    }

    public DialogueObject GetCurrentDialogue(ActorTypes id, int idx) {
        return Array.Find<DialogueObject>(sceneDialogues, d => d.actorIdentifier == id && (d.index == 0 || d.index == idx));
    }

    public void NextGameState() {
        Debug.Log("Switching Game State");
        switch (GameState) {
            case GameState.NEW_IN_TOWN: {
                GameState = GameState.SCANDAL;
                sceneDialogues = scandalDialogues;
                break;
            }
            case GameState.SCANDAL: {
                GameState = GameState.MAYORS_PERMISSION;
                sceneDialogues = mayorsPermissionDialogues;
                break;
            }
            case GameState.MAYORS_PERMISSION: {
                GameState = GameState.JAIL_VISIT;
                sceneDialogues = jailVisitDialogues;
                break;
            }
            case GameState.JAIL_VISIT: {
                keysVisible = false;
                GameObject keys = Array.Find(activeNPCs, g => g.name == "Keys");
                if (keys != null) {
                    keys.SetActive(false);
                }
                GameState = GameState.TOUGHBALL_TALK;
                sceneDialogues = toughballTalkDialogues;
                break;
            }
            case GameState.TOUGHBALL_TALK: {
                GameState = GameState.COFFEE_BREAK;
                sceneDialogues = coffeeBreakDialogues;
                break;
            }
            case GameState.COFFEE_BREAK: {
                GameState = GameState.APOLOGIZE;
                sceneDialogues = apologizeDialogues;
                break;
            }
            case GameState.FINALE: {
                sceneDialogues = finaleDialogues;
                break;
            }
        }
        dialogueIndex = 1;
        ActualizeDialogues();
    }

    public void IncreaseDialogueIndex() {
        dialogueIndex++;
        ActualizeDialogues();
    }

    public void ActualizeDialogues() {
        foreach (GameObject npc in activeNPCs) {
            NPC npcBehaviour = npc.GetComponent<NPC>();
            npcBehaviour.currentDialogue = GetCurrentDialogue(npcBehaviour.actorType,  dialogueIndex);
        }
    }

    public bool AllDialoguesSeen() {
        foreach(DialogueObject dialogue in sceneDialogues) {
            if (!dialogue.seen) {
                return false;
            }
        }
        return true;
    }
}
