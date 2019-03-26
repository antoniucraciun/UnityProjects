using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealArea : MonoBehaviour
{
    [Range(6, 32)]
    public int points;
    public LineRenderer line;
    //public CircleCollider2D coll;

    public float radius = 1;
    public Vector3[] circlePoints;
    void Start () {
		
	}
	
	void Update ()
    {
        circlePoints = new Vector3[points + 1];
        for (int i = 0; i < circlePoints.Length; i++)
        {
            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            circlePoints[i] = new Vector3(x, y, 0) * radius + transform.position;
        }
        circlePoints[circlePoints.Length - 1] = circlePoints[0];
        line.positionCount = circlePoints.Length;
        line.SetPositions(circlePoints);
    }
}
