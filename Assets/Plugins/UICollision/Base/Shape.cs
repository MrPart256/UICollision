using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Shape
{
    public Shape(CanvasScaler scaler)
    {
        m_scaler = scaler;
    }

    public abstract Vector2[] Verticies
    {
        get;
    }

    protected readonly CanvasScaler m_scaler;
}
