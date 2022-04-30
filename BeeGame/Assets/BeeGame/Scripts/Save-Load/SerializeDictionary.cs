using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// code is from How to make a Save & Load System in Unity | 2022 https://www.youtube.com/watch?v=aUi9aijvpg by Trevor Mock
// serialises the dictionary values so that they can be saved to and loaded from the gamedata file
[System.Serializable]
public class SerializeDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();

        if (keys.Count != values.Count)
        {
            Debug.LogError("The number of keys " + keys.Count + " in this dictionary does not match the number of values " + values.Count);
        }

        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}
