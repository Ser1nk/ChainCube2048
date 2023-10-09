using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TouchInput))]
public class Movement : MonoBehaviour
{
    public event Action OnPulseEnd;

    private Transform _rightBorder;
    private Transform _leftBorder;

    private Rigidbody _rigidbody;

    private float _directionSpeed = 0.7f;
    private float _forwardImpulseSpeed = 12f;

    private float _swipeDelta;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveTouch();
    }

    public void Impulse()
    {
        _rigidbody.AddForce(transform.forward * _forwardImpulseSpeed, ForceMode.Impulse);
        Destroy(GetComponent<Movement>());
        Destroy(GetComponent<TouchInput>());
       
        OnPulseEnd?.Invoke();
    }

    public void MoveTouch()
    {
        transform.Translate(_swipeDelta * _directionSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x > _rightBorder.transform.position.x)
            transform.position = _rightBorder.transform.position;
        if (transform.position.x < _leftBorder.transform.position.x)
            transform.position = _leftBorder.transform.position;
    }

    public void GetSwipeDelta(float swipeDelta)
    {
        _swipeDelta = Mathf.Clamp(transform.position.x, -1, 2);

        _swipeDelta = swipeDelta;
    }

    public void GetTransfromBorders(Transform rightBorder, Transform leftBorder)
    {
        _rightBorder = rightBorder;
        _leftBorder = leftBorder;
    }

    public void Stop()
    {
        _directionSpeed = 0;
        _forwardImpulseSpeed = 0;
    }
}

