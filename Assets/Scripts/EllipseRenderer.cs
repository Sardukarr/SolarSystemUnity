using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lr;

    [Range(3, 36)]
    public int segments;
    public Ellipse ellipse;
   // public float axisX=5f;
   // public float axisY=3f;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }
    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for(int i = 0; i <segments; i++)
        {
           // float angle = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
            Vector2 pos = ellipse.Evaluate((float)i / (float)segments);

            //float x = Mathf.Sin(angle) * axisX;
           // float y = Mathf.Cos(angle) * axisY;
            points[i] = new Vector3(pos.x, pos.y, 0f);
        }
        points[segments] = points[0];
        lr.useWorldSpace = false;
        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }
    private void Update()
    {
        if (Application.isPlaying) 
            CalculateEllipse();
            
    }
}
