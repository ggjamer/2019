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

    public List<StateInfo> stateInfos;
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
    public Sprite playerSprite;
    private Player _playerBehaviour;
    public Vector3 PlayerPosition;
    
    //NPC Infos
    public GameObject mayor;
    public GameObject boatman;
    public GameObject policeman;
    public GameObject daddy;
    public GameObject barkeeper;
    public GameObject innkeeper;
    public GameObject storekeeper;
    public GameObject priest;
    private List<GameObject> activeNPCs;
    
    // Game State infos
    public GameState GameState;
    public StateInfo[] StateInfos;
    private Locations _location;
    
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
        _playerBehaviour.SetParams(playerName, playerSprite);
        _playerBehaviour.Init();

        _location = StateInfos[(int) GameState].initialLocation;
        
        //Create NPCs
        foreach (ActorTypes npc in GetPeopleAtLocation(_location)) {
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
                npc = Instantiate(daddy);
                break;
            }
            case ActorTypes.BOATMAN: {
                npc = Instantiate(boatman);
                break;
            }
            case ActorTypes.MAYOR: {
                npc = Instantiate(mayor);
                break;
            }
            case ActorTypes.POLICEMAN: {
                npc = Instantiate(policeman);
                break;
            }
            case ActorTypes.BARKEEPER: {
                npc = Instantiate(barkeeper);
                break;
            }
            case ActorTypes.INNKEEPER: {
                npc = Instantiate(innkeeper);
                break;
            }
            case ActorTypes.STOREKEEPER: {
                npc = Instantiate(storekeeper);
                break;
            }
            case ActorTypes.PRIEST: {
                npc = Instantiate(priest);
                break;
            }
            default: {
                throw new InvalidExpressionException("Invalid NPC Type");
            }
        }

        NPC npcBehaviour = npc.AddComponent<NPC>();
        npcBehaviour.actorType = npcType;
        if (_location == Locations.OUTSIDE) {
            npc.transform.position = npcBehaviour.OutdoorPosition;
        }
        activeNPCs.Add(npc);
    }

    public List<ActorTypes> GetPeopleAtLocation(Locations location) {
        List<ActorTypes> results = new List<ActorTypes>();
        StateInfo stateInfo = stateInfos[(int) GameState];
        
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
