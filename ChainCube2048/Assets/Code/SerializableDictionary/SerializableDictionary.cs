using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [SerializeField] private List<SerializableDictionaryElement<TKey, TValue>> _dictionaryElements;

    public TValue GetValue(TKey key)
    {
        foreach (var element in _dictionaryElements)
        {
            if (EqualityComparer<TKey>.Default.Equals(element.Key, key))
                return element.Value;
        }

        throw new ArgumentOutOfRangeException(nameof(key));
    }
}
