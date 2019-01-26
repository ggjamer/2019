using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInfo : ScriptableObject
{
    //Interactible components;
    public bool counter;
    public bool coffeeBox;
    
    //Inventory
    public List<Item> inventory = new List<Item>();
    
    //People locations
    public Dictionary<NPC, Locations> peopleLocations = new Dictionary<NPC, Locations>();
    
    //Dialogues
}