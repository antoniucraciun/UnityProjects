using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPattern : Pattern
{
    public Vector2 offset;

    [SerializeField] protected int gridSizeX;
    [SerializeField] protected int gridSizeY;

    void Start()
    {
        positions = new Vector2[gridSizeX * gridSizeY];
        SetPositions();
    }

    public override void SetPositions()
    {
        base.SetPositions();
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 pos = new Vector2(x * distanceBetweenPositions, y * distanceBetweenPositions);
                pos -= new Vector2(gridSizeX / 2 * distanceBetweenPositions - distanceBetweenPositions / 2, 
                                    gridSizeY / 2 * distanceBetweenPositions - distanceBetweenPositions / 2) + offset;
                positions[x * gridSizeX + y] = pos;
            }
        }
        base.positionsSet = true;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
