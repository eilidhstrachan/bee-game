using UnityEngine;

// this class is the base state for every NPC state to implement
public abstract class NPCBaseState
{
    // method to be called when entering state
    public abstract void EnterState(NPCStateManager npc);

    // method to be called in Update for the current state
    public abstract void UpdateState(NPCStateManager npc);

}
