using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public Vector3 GetPosition()
    {
        return _transform.position;
    }

    public void SetPosition(Vector3 startPoint)
    {
        _transform.position = startPoint;
    }

    public void SetVelocity()
    {

    }
}
