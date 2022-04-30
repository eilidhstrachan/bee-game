using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

/*
 * This class uses observers to handle if there is a variable that has been changed in the Ink file being run.
 * Made with the help of How to persist variables across multiple Ink stories (Variable Observer) | Unity + Ink tutorial 2021 - https://www.youtube.com/watch?v=fA79neqH21s
 */
public class DialogueValues
{
    public static string choice = "";

    // enables the observer
    public void ObserverEnabled(Story story)
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    // disables the observer
    public void ObserverDisabled(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    // when the variable changes, parses the variable value to a string and sets the choice variable to that string
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        Debug.Log("A variable was changed = "+ name +" = "+ value);
        choice = value.ToString();
        Debug.Log("value is "+ choice);

    }

}
