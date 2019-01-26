using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInfo : ScriptableObject
{
    //Interactible locations
    public List<Locations> locations = new List<Locations>();
    
    //Interactible components;
    public bool counter;
    public bool coffeeBox;
    
    //Inventory
    public List<Objects> inventory = new List<Objects>();
    
    //People locations
    public Dictionary<People, Locations> peopleLocations = new Dictionary<People, Locations>();
    
    //Dialogues
}