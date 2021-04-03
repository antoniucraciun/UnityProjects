using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(Shape))]
[RequireComponent(typeof(ColliderShape))]

public class EnemyController : MonoBehaviour
{
	[Range(3, 64)]
	private int lastPointCount;
	[Range(3, 64)]
	public int points;

	public float radius = 2.5f;
	private float lastRadius;

	public EnemyHealth enemyHealth;
	public Shape shape;
	public ColliderShape colliderShape;

	private void Start()
	{
		lastPointCount = points;
		lastRadius = radius;
		enemyHealth = GetComponent<EnemyHealth>();
		shape = GetComponent<Shape>();
		colliderShape = GetComponent<ColliderShape>();
		colliderShape.OnVariablesChanged += ChangeColliderOptions;
	}

	private void Update()
	{
		if (points != lastPointCount || radius != lastRadius)
		{

		}
	}

	private void ChangeColliderOptions()
	{
		colliderShape.SetNumberOfPoints(points);
		colliderShape.SetRadius(radius);
	}
}
