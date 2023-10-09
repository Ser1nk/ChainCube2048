using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private Movement _movement;

    private float _swipeDelta;
    private float _startTouch;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouch = touch.position.x;
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                _swipeDelta = touch.position.x - _startTouch;
                _startTouch = touch.position.x;
            }
            if (touch.phase == TouchPhase.Ended)
            {   
                _swipeDelta = 0;
                _movement.Impulse();
            }

            _movement.GetSwipeDelta(_swipeDelta);
        }
    }
}
