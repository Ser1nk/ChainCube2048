using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSettings : MonoBehaviour
{
    public static CubeSettings Instance { get; private set; }

    [SerializeField] private SerializableDictionary<int, Material> _cubeTypeDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public Material GetMaterial(int materialKey)
    {
        return _cubeTypeDictionary.GetValue(materialKey);
    }
}
