using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
	public Vector3 target;
	public NavMeshAgent agent;
	public Animator anim;

	private Vector3 offset = new Vector3(.3f, .3f, .3f);
	private bool talking;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}

	void Update()
    {
		if(target != null && !talking)
			agent.Move(target + offset);
		anim.SetBool("isTalking", talking);
    }

	public void SetDestination(Vector3 t)
	{
		target = t;
	}

	public void SetTalking(bool isTalking)
	{
		talking = isTalking;
	}
}
