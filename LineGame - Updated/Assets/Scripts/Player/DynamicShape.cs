using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class DynamicShape : MonoBehaviour
{
    [Range(6, 32)]
    public int points;
    public LineRenderer line;
    public CircleCollider2D coll;

    public float radius = 2.5f;
    public Vector3[] circlePoints;
    public Vector3 offset;

    public bool useCollider = true;
    public bool useOffset = true;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        if (useCollider)
            coll = GetComponent<CircleCollider2D>();
        if (!useOffset)
            offset = Vector3.zero;
        if (useCollider)
        {
            coll.radius = radius;
            coll.offset = new Vector2(0, 0.75f);
        }
    }

    void Update()
    {
        circlePoints = new Vector3[points + 1];
        for (int i = 0; i < circlePoints.Length; i++)
        {
            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            circlePoints[i] = new Vector3(x, y, 0) * radius + offset;
        }
        circlePoints[circlePoints.Length - 1] = circlePoints[0];
        line.positionCount = circlePoints.Length;
        line.SetPositions(circlePoints);
    }

    public void SetRadius(float rad)
    {
        this.radius = rad;
        if (useCollider)
            coll.radius = rad;
    }

    public void SetNumberOfPoints(int nrPoints)
    {
        this.points = nrPoints;
    }

    public void SetOffset(Vector3 offset)
    {
        this.offset = offset;
        if (useCollider)
            coll.offset = offset;
    }
}
