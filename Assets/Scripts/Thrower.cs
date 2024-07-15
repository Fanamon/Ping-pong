using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower
{
    public Vector3 CalculateVelocityByHeight(Vector3 startPoint, 
        Vector3 endPoint, float height)
    {
        float timeToRise = CalculateTimeByHeight(height);
        float timeToFall = CalculateTimeByHeight(height + 
            (startPoint - endPoint).y);
        Vector3 horizontalVelocity = endPoint - startPoint;
        horizontalVelocity.y = 0;
        horizontalVelocity /= (timeToRise + timeToFall);

        Vector3 verticalVelocity = -Physics.gravity * timeToRise;

        return horizontalVelocity + verticalVelocity;
    }

    private float CalculateTimeByHeight(float height)
    {
        float gravityFactor = Mathf.Abs(Physics.gravity.y);
        return Mathf.Sqrt((height * 2f) / gravityFactor);
    }
}
