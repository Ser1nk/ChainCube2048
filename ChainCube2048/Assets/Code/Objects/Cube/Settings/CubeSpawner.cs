using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private GameObject _cubePrefab;

    [SerializeField] private Transform _spawnPoint;

    [Header("Borders")]
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _leftBorder;

    private GameObject _newCube;

    private float _spawnDelay = 0.5f;

    private void Start()
    {
        OnPulseEnd();
    }

    private void OnPulseEnd()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return null;
        yield return new WaitForSeconds(_spawnDelay);
        _newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
        _newCube.AddComponent<Movement>().GetTransfromBorders(_rightBorder, _leftBorder);
        _newCube.GetComponent<Movement>().OnPulseEnd += OnPulseEnd;
    }
}
