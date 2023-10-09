using UnityEngine;
using TMPro;

public class CubeValueDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _text;

    [SerializeField] private Cube _cube;

    private void OnEnable() => _cube.Initialize += SetCubeValue;

    private void OnDisable() => _cube.Initialize -= SetCubeValue;

    private void SetCubeValue(int cubeValue)
    {
        for (int i = 0; i < _text.Length; i++)
            _text[i].text = cubeValue.ToString();
    }
}
