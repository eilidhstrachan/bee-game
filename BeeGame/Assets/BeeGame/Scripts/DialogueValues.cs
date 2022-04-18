using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueValues 
{
    public string choice;

    public void ObserverEnabled(Story story)
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void ObserverDisabled(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        Debug.Log("A variable was changed = "+ name +" = "+ value);
        choice = value.ToString();
        Debug.Log("value = "+ value);
    }
}
