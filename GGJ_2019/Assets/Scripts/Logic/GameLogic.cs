using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        _gameState = GameState.NEW_IN_TOWN;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_gameState) {
        }
    }
}
