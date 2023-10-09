using System;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour, IMeargeable
{
    public static UnityAction<int> OnCubeMergeStatic;

    public event UnityAction<int> Initialize;
    public event Action OnCubeMerged;
    public event Action OnCubePushed;

    [SerializeField] private int _cubeValue = 2;

    private Vector3 _randomRotation;
    
    private bool _isLocked;

    private float _forwardForce = 5f;
    private float _upForce = 6f;
    private float _pushForce = 2f;

    private void Start()
    {
        Initialize?.Invoke(_cubeValue);
    }

    private void OnValidate()
    {
        if (((_cubeValue - 1) & _cubeValue) != 0 || _cubeValue > 1024)
        {
            _cubeValue = 0;

            Debug.LogError(GlobalStringVars.NotCorrectNumber);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_isLocked)
            return;

        if (collision.gameObject.TryGetComponent(out Cube otherCube))
        {
            Vector3 pushDirection = (otherCube.transform.position - transform.position).normalized;
            otherCube.GetComponent<Rigidbody>().AddForce(pushDirection * _pushForce, ForceMode.Impulse);
            OnCubePushed?.Invoke();

            if (_cubeValue == otherCube._cubeValue)
                Merge(otherCube);
        }
    }

    public void Merge(Cube otherCube)
    {
        otherCube._isLocked = true;

        GameObject newCubeGameOject = Instantiate(gameObject, Vector3.Lerp(transform.position, otherCube.transform.position, 0.5f), Quaternion.identity);
        Cube newCube = newCubeGameOject.GetComponent<Cube>();

        newCube._cubeValue = _cubeValue + otherCube._cubeValue;

        newCube.Initialize?.Invoke(newCube._cubeValue);
        newCube.OnCubeMerged?.Invoke();
        OnCubeMergeStatic?.Invoke(newCube._cubeValue);

        _randomRotation = new Vector3(UnityEngine.Random.Range(-180f, 180f), UnityEngine.Random.Range(-180f, 180f), UnityEngine.Random.Range(-180f, 180f));

        newCube.GetComponent<Rigidbody>().AddForce(transform.forward * _forwardForce, ForceMode.Impulse);
        newCube.GetComponent<Rigidbody>().AddForce(transform.up * _upForce, ForceMode.Impulse);
        newCube.GetComponent<Rigidbody>().AddTorque(_randomRotation, ForceMode.Impulse);

        Destroy(gameObject);
        Destroy(otherCube.gameObject);
    }
}
