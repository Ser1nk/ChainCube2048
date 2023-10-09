using System;
using UnityEngine;

[Serializable]
public class SerializableDictionaryElement<TKey, TValue>
{
    [field: SerializeField] public TKey Key { get; private set; }
    [field: SerializeField] public TValue Value { get; private set; }
}
