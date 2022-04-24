using UnityEngine;

public class NPCIntroState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        Debug.Log("I'm now in entering the intro state! - "+ npc.GetComponent<NPCStateManager>().NPCName);
       
    }


    public override void UpdateState(NPCStateManager npc)
    {
        if (npc.GetComponent<NPCStateManager>().playerInRange == false || npc.introsHeard == true)
        {
            npc.ChangeState(npc.IdleState);
        }

        if (!DialogueManager.GetInstance().dialogueIsRunning)
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = npc.GetComponent<NPCStateManager>().NPCName;
                npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
                DialogueManager.GetInstance().StartDialogue(npc.GetComponent<NPCStateManager>().inkIntro);
                npc.GetComponent<NPCStateManager>().introsHeard = true;
            }
            else
            {
                npc.GetComponent<NPCStateManager>().nametagText.text = "";
            }
        }
        else
        {
            npc.GetComponent<NPCStateManager>().prompt.SetActive(false);
        }
    }
}
