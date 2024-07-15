using System;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public event Action CollisionEntered;

    private void OnCollisionEnter(Collision collision)
    {
        var collisionRigidbody = collision.collider.attachedRigidbody;

        if (collisionRigidbody != null)
        {
            if (collisionRigidbody.GetComponent<Ball>() != null)
            {
                CollisionEntered?.Invoke();
            }
        }
    }
}