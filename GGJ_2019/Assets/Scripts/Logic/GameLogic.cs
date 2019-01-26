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
    private GameObject player;
    public string playerName;
    public RuntimeAnimatorController animatorController;
    private Player _playerBehaviour;
    public Vector3 PlayerPosition;
    
    //NPC Infos
    private List<GameObject> activeNPCs = new List<GameObject>();
    
    // Game State infos
    public GameState GameState;
    public StateInfo[] StateInfos;
    public Locations Location;
    
    // Camera Infos
    public Vector3 CameraPosition;
    public float Zoom;

    void Awake() {
        _instance = this;
        SceneManager.sceneLoaded += init;
        GameState = GameState.NEW_IN_TOWN;
    }

    void init(Scene scene, LoadSceneMode mode) {
        // Create Player
        player = Instantiate(playerObj);
        _playerBehaviour = player.GetComponent<Player>();
        _playerBehaviour.SetParams(playerName, animatorController);
        _playerBehaviour.Init();
        
        //Create NPCs
        List<ActorTypes> npcs = GetPeopleAtLocation(Location);
        foreach (ActorTypes npc in npcs) {
            CreateNPC(npc);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        switch(GameState) {
            case GameState.NEW_IN_TOWN: {
                newInTown();
                break;
            }
            case GameState.SCANDAL: {
                scandal();
                break;
            }
            case GameState.MAYORS_PERMISSION: {
                mayorsPermission();
                break;
            }
            case GameState.JAIL_VISIT: {
                jailVisit();
                break;
            }
            case GameState.TOUGHBALL_TALK: {
                toughballTalk();
                break;
            }
            case GameState.COFFEE_BREAK: {
                coffeeBreak();
                break;
            }
            case GameState.FINALE: {
                finale();
                break;
            }
            default: {
                throw new InvalidExpressionException("Invalid Game State");
            }
        }
    }

    private void newInTown() {
        
    }

    private void scandal() {
        
    }

    private void mayorsPermission() {
        
    }

    private void jailVisit() {
        
    }

    private void toughballTalk() {
        
    }

    private void coffeeBreak() {
        
    }

    private void finale() {
        
    }

    private void CreateNPC(ActorTypes npcType) {
        GameObject npc;
        switch (npcType) {
            case ActorTypes.DADDY: {
                npc = GameObject.Find("Daddy");
                break;
            }
            case ActorTypes.BOATMAN: {
                npc = GameObject.Find("Boatman");
                break;
            }
            case ActorTypes.MAYOR: {
                npc = GameObject.Find("Mayor");
                break;
            }
            case ActorTypes.POLICEMAN: {
                npc = GameObject.Find("Policeman");
                break;
            }
            case ActorTypes.BARKEEPER: {
                npc = GameObject.Find("Barkeeper");
                break;
            }
            case ActorTypes.INNKEEPER: {
                npc = GameObject.Find("Innkeeper");
                break;
            }
            case ActorTypes.STOREKEEPER: {
                npc = GameObject.Find("Storekeeper");
                break;
            }
            case ActorTypes.PRIEST: {
                npc = GameObject.Find("Priest");
                break;
            }
            default: {
                throw new InvalidExpressionException("Invalid NPC Type");
            }
        }

        activeNPCs.Add(npc);
    }

    public List<ActorTypes> GetPeopleAtLocation(Locations location) {
        List<ActorTypes> results = new List<ActorTypes>();
        StateInfo stateInfo = StateInfos[(int) GameState];
        
        Debug.Log(stateInfo);
        Debug.Log(location);
        // This is so ugly :(
        if (stateInfo.DADDY == location) {
            results.Add(ActorTypes.DADDY);
        }
        if (stateInfo.BOATMAN == location) {
            results.Add(ActorTypes.BOATMAN);
        }
        if (stateInfo.MAYOR == location) {
            results.Add(ActorTypes.MAYOR);
        }
        if (stateInfo.POLICEMAN == location) {
            results.Add(ActorTypes.POLICEMAN);
        }
        if (stateInfo.BARKEEPER == location) {
            results.Add(ActorTypes.BARKEEPER);
        }
        if (stateInfo.INNKEEPER == location) {
            results.Add(ActorTypes.INNKEEPER);
        }
        if (stateInfo.STOREKEEPER == location) {
            results.Add(ActorTypes.STOREKEEPER);
        }
        if (stateInfo.PRIEST == location) {
            results.Add(ActorTypes.PRIEST);
        }
        return results;
    }
}
