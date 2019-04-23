using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse
{
    public float axisX;
    public float axisY;

    public Ellipse(float x, float y,Vector3 Center)
    {
        axisX = x + Center.x;
        axisY = y + Center.z;
    }

    public Vector2 Evaluate(float t)
    {
        float angle = Mathf.Deg2Rad * 360f * t;
        float x = Mathf.Sin(angle) * axisX;
        float y = Mathf.Cos(angle) * axisY;


        return new Vector2(x, y);
    }
}
