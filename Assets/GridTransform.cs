using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IntVector2
{
    public int x;
    public int y;

    public static implicit operator IntVector2(Vector2 v)
    {
        return new IntVector2()
        {
            x = (int)v.x,
            y = (int)v.y
        };
    }

    public static implicit operator Vector2(IntVector2 v)
    {
        return new Vector2()
        {
            x = v.x,
            y = v.y
        };
    }
}

public class GridTransform : MonoBehaviour
{
    public IntVector2 Position;

	void Update ()
    {
        if (gridGeneratorScript.instance == null) { return; }
        transform.position = gridGeneratorScript.instance.mapGrid[Position.x, Position.y].pos;
    }
}
