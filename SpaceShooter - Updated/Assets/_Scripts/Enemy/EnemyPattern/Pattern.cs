using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pattern : MonoBehaviour
{
    protected bool positionsSet = false;

    protected Vector2[] positions;
    [SerializeField] protected float distanceBetweenPositions;

    public virtual void SetPositions() { }

    public virtual void OnDrawGizmos()
    {
        if (positionsSet)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                Gizmos.DrawWireSphere(positions[i], .25f);
            }
        }
    }

    public Vector2 GetPositionAt(int index)
    {
        if (index >= positions.Length)
            return Vector2.zero;
        return positions[index];
    }
}
