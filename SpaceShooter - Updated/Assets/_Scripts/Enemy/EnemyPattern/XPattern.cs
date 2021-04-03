using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPattern : Pattern
{
    public Vector2 offset;

    [SerializeField] protected int gridSizeX;
    [SerializeField] protected int gridSizeY;

    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector2[gridSizeX * gridSizeY];
        SetPositions();
    }

    public override void SetPositions()
    {
        base.SetPositions();
        int count = 0;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if (x == y || x + y + 1 == gridSizeX)
                {
                    Vector2 pos = new Vector2(x * distanceBetweenPositions, y * distanceBetweenPositions);
                    pos -= new Vector2(gridSizeX / 2 * distanceBetweenPositions - distanceBetweenPositions / 2,
                                    gridSizeY / 2 * distanceBetweenPositions - distanceBetweenPositions / 2) + offset;
                    positions[x * gridSizeX + y] = pos;
                    count++;
                }
            }
        }
        Vector2[] availablePositions = new Vector2[count];
        int index = 0;
        for (int i = 0; i < positions.Length; i++)
        {
            if(positions[i] != Vector2.zero)
            {
                availablePositions[index] = positions[i];
                index++;
            }
        }
        positions = availablePositions;
        base.positionsSet = true;
    }


    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
