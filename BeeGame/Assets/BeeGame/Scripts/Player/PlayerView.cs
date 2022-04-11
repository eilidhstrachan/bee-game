using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : VillageElement, IDataManagement
{

    void Update()
    {
        app.controller.player.OnUpdate();
        Debug.Log("player position " + app.model.player.playerObject.transform.position);

    }
    void FixedUpdate()
    {
        app.controller.player.OnFixedUpdate();
    }

    public void LoadData(GameData data)
    {
        Debug.Log("loading player position");
        this.app.model.player.playerObject.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        //Debug.Log("saving player position " + this.app.model.player.playerObject.transform.position);
        data.playerPosition = this.app.model.player.playerObject.transform.position;
    }


}

