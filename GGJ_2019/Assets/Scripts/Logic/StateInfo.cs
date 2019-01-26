using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "GameState", order = 1)]
public class StateInfo : ScriptableObject
{
    //Interactible components;
    public bool counter;
    public bool coffeeBox;
    
    //Inventory
    public List<Item> inventory;
    
    //People locations
    public Locations MAYOR;
    public Locations BOATMAN;
    public Locations DADDY;
    public Locations POLICEMAN;
    public Locations BARKEEPER;
    public Locations INNKEEPER;
    public Locations STOREKEEPER;
    public Locations PRIEST;
    
    //Dialogues
}