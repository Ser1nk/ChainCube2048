using UnityEngine;

public class CubeColor : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnEnable() => _cube.Initialize += SetCubeColor;

    private void OnDisable() => _cube.Initialize -= SetCubeColor;

    private void SetCubeColor(int cubeValue)
    {
        GetComponent<Renderer>().material = CubeSettings.Instance.GetMaterial(cubeValue);
    }
}
