using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private static GameLogic _instance;
    public static GameLogic Instance {
        get {
            return _instance;
        }
    }
    
    private GameState _gameState;
    
    void Awake() {
        _instance = this;
    }
    
    // Start is called before the first frame update
    void Start() {
        _gameState = GameState.NEW_IN_TOWN;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_gameState) {
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
}
