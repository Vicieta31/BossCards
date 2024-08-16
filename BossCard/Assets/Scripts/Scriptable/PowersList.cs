using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[CreateAssetMenu]
public class PowersList : ScriptableObject, ISerializationCallbackReceiver
{
    public List<int> powersInitial = new List<int>() { 0, 0, 0 };

    [HideInInspector]
    public List<int> RunTimeValue;

    public void OnAfterDeserialize()
    {
        // Ensure RunTimeValue is a new list with the same elements as powersInitial
        RunTimeValue = new List<int>(powersInitial);
    }

    public void OnBeforeSerialize()
    {
        // You can leave this empty unless you have a reason to modify the list before serialization
    }
}
