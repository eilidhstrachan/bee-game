using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the base class for all elements in the game
public class VillageElement : MonoBehaviour
{
    // Gives access to the application and all instances of it 
    public VillageApplication app { get { return GameObject.FindObjectOfType<VillageApplication>(); } }
}


public class VillageApplication : MonoBehaviour
{
    // These are the root MVC instances
    public VillageModel model;
    public VillageView view;
    public VillageController controller;

    
    void Start() { }
}
