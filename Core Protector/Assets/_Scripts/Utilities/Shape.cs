using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Shape : MonoBehaviour
{
    [Range(3, 64)]
    public int points;
    public LineRenderer line;

    public float radius = 2.5f;
    public Vector3[] circlePoints;
    public Vector3 offset;
    
    public bool useOffset = true;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        offset = transform.position;
    }

    void Update()
    {
        if (useOffset)
            offset = transform.position;
        circlePoints = new Vector3[points + 2];
        for (int i = 0; i < circlePoints.Length; i++)
        {
            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            circlePoints[i] = new Vector3(x, y, 0) * radius;
        }
        circlePoints[circlePoints.Length - 2] = circlePoints[0];
        circlePoints[circlePoints.Length - 1] = circlePoints[1];
        line.positionCount = circlePoints.Length;
        line.SetPositions(circlePoints);
    }

    public void SetRadius(float rad)
    {
        this.radius = rad;
    }

    public void SetNumberOfPoints(int nrPoints)
    {
        this.points = nrPoints;
    }

    public void ReduceNumberOfPoints()
    {
        if (points >= 12)
        {
            points = points / 2;
        }
    }
}
