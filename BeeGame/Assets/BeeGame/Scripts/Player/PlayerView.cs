using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class contains the Update() and FixedUpdate() methods for the player gameobject, uses the controller methods OnUpdate() and OnFixedUpdate()
 */
public class PlayerView : VillageElement
{

    void Update()
    { 
        app.controller.player.OnUpdate();

    }

    void FixedUpdate()
    {
        app.controller.player.OnFixedUpdate();
    }



}

