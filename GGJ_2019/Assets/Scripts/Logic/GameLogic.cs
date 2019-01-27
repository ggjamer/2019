using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;
using UnityEditor.VersionControl;
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
    public DialogueObject[] finaleDialogues;
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
        player = Instantiate(playerObj);
        _playerBehaviour = player.GetComponent<Player>();
        _playerBehaviour.SetParams(playerName, animatorController);
        _playerBehaviour.Init();
        
        //Create NPCs
        activeNPCs = GameObject.FindGameObjectsWithTag("NPC");
        if (!keysVisible) {
            GameObject keys = Array.Find(activeNPCs, g => g.name == "Keys");
            if (keys != null) {
                keys.SetActive(false);
            }
        }
        ActualizeDialogues();
    }

    public DialogueObject GetCurrentDialogue(ActorTypes id, int idx) {
        DialogueObject[] array = newInTownDialogues; 
        switch (GameState) {
            case GameState.NEW_IN_TOWN: {
                array = newInTownDialogues;
                break;
            }
            case GameState.SCANDAL: {
                array = scandalDialogues;
                break;
            }
            case GameState.MAYORS_PERMISSION: {
                array = mayorsPermissionDialogues;
                break;
            }
            case GameState.JAIL_VISIT: {
                array = jailVisitDialogues;
                break;
            }
            case GameState.TOUGHBALL_TALK: {
                array = toughballTalkDialogues;
                break;
            }
            case GameState.COFFEE_BREAK: {
                array = coffeeBreakDialogues;
                break;
            }
            case GameState.FINALE: {
                array = finaleDialogues;
                break;
            }
        }

        return Array.Find<DialogueObject>(array, d => d.actorIdentifier == id && (d.index == 0 || d.index == idx));
    }

    public void NextGameState() {
        Debug.Log("Switching Game State");
        switch (GameState) {
            case GameState.NEW_IN_TOWN: {
                GameState = GameState.SCANDAL;
                break;
            }
            case GameState.SCANDAL: {
                GameState = GameState.MAYORS_PERMISSION;
                break;
            }
            case GameState.MAYORS_PERMISSION: {
                GameState = GameState.JAIL_VISIT;
                break;
            }
            case GameState.JAIL_VISIT: {
                keysVisible = false;
                GameState = GameState.TOUGHBALL_TALK;
                break;
            }
            case GameState.TOUGHBALL_TALK: {
                GameState = GameState.COFFEE_BREAK;
                break;
            }
            case GameState.COFFEE_BREAK: {
                GameState = GameState.FINALE;
                break;
            }
            case GameState.FINALE: {
                return;
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
}
