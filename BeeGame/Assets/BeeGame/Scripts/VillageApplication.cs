using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all elements in this application.
public class VillageElement : MonoBehaviour
{
    // Gives access to the application and all instances.
    public VillageApplication app { get { return GameObject.FindObjectOfType<VillageApplication>(); } }
}

// 10 Bounces Entry Point.
public class VillageApplication : MonoBehaviour
{
    // Reference to the root instances of the MVC.
    public VillageModel model;
    public VillageView view;
    public VillageController controller;

    // Init things here
    void Start() { }
}
