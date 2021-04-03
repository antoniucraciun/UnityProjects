#if UNITY_EDITOR
#define DEBUG_LogStateController
#endif
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class StateController : MonoBehaviour
{
    public EnemyController enemyController;
    public Transform shootingPoint;
    public State currentState;
    public State remainState;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();

#if DEBUG_LogStateController
        if (shootingPoint == null)
            Debug.LogError("Shooting point not set");
#endif

    }

    private void Update()
    {
        if (!gameObject.activeInHierarchy)
            return;

        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && shootingPoint != null && enemyController != null)
        {
            Gizmos.color = currentState.sceneGizmosColor;
            Gizmos.DrawWireSphere(shootingPoint.position, enemyController.enemyData.enemySizeSphere);
        }
    }
}
