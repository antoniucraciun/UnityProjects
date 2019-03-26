using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCircle : MonoBehaviour {

    [Range(6, 32)]
    public int points;
    public LineRenderer line;
    public CircleCollider2D coll;

    public float radius = 1;
    public Vector3[] circlePoints;

    private void Start()
    {
        radius = 0.1f;
    }

    void Update ()
    {
        radius = Mathf.Lerp(radius, 20, Time.deltaTime);
        coll.radius = radius;
        if (radius >= 19.5f)
            Destroy(gameObject);
        circlePoints = new Vector3[points + 1];
        for (int i = 0; i < circlePoints.Length; i++)
        {
            float x = Mathf.Cos(i / (float)points * 2 * Mathf.PI);
            float y = Mathf.Sin(i / (float)points * 2 * Mathf.PI);
            circlePoints[i] = new Vector3(x, y, 0) * radius;
        }
        circlePoints[circlePoints.Length - 1] = circlePoints[0];
        line.positionCount = circlePoints.Length;
        line.SetPositions(circlePoints);
	}

    public void SetRadius(float rad)
    {
        radius = rad;
    }

    public void SetNumberOfPoints(int nrPoints)
    {
        points = nrPoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(Data.pulseDamage + 1);
        }
        if (collision.tag == "Shot")
        {
            Destroy(collision.gameObject);
        }
    }
}
