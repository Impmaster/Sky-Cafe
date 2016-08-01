using UnityEngine;

public class CloudMove : MonoBehaviour
{


    public enum MoveAxis { X, Y, Z }

    public float Speed = 10;
    public MoveAxis Axis = MoveAxis.X;
    public float Distance = 20;

    private Vector3 _origin;

    Vector3 newPosition;


    void Start()
    {
        _origin = transform.localPosition;
    }

    void Update()
    {
        Vector3 axis = Vector3.zero;
        switch (Axis)
        {
            case MoveAxis.X: axis = Vector3.right; break;
            case MoveAxis.Y: axis = Vector3.up; break;
            case MoveAxis.Z: axis = Vector3.forward; break;
        }

        // Bounce from 0 to 1 and back
        float pos = Time.time * Speed / Distance;
        pos %= 2;
        if (pos > 1) pos = 2 - pos;

        // Ease
        pos = easeInOutSine(pos, 0, 1, 1);

        // Translate
        newPosition = _origin + axis * Distance * pos;
        transform.localPosition = newPosition;

    }

    private float easeInOutSine(float t, float b, float c, float d)
    {
        // based on http://gizma.com/easing/#sin3
        //sinusoidal easing in/out - accelerating until halfway, then decelerating
        //t = current time
        //b = start value
        //c = change in value
        //d = duration
        return -c / 2 * (Mathf.Cos(Mathf.PI * t / d) - 1) + b;
    }

}
