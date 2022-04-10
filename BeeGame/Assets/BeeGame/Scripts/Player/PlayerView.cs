using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

