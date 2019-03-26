using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class ColliderShape : MonoBehaviour
{
    [Range(3, 64)]
    public int points = 3;
    public EdgeCollider2D coll;

    public float radius = 2.5f;
    public Vector2[] circlePoints;
    
    private void Start()
    {
        coll = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        circlePoints = new Vector2[points + 2];
        for (int i = 0; i < circlePoints.Length; i++)
        {
            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            circlePoints[i] = new Vector2(x, y) * radius;
        }
        circlePoints[circlePoints.Length - 2] = circlePoints[0];
        circlePoints[circlePoints.Length - 1] = circlePoints[1];
        coll.points = circlePoints;
    }

    public void SetRadius(float rad)
    {
        this.radius = rad;
    }

    public void SetNumberOfPoints(int nrPoints)
    {
        this.points = nrPoints;
    }
}
