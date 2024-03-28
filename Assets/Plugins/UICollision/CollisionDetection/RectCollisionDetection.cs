using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectCollisionDetection : CollisionDetection
{
    public override bool Resolve(UICollider col, UICollider pair)
    {

        if (col.Shape.Verticies[0].x < pair.Shape.Verticies[3].x && col.Shape.Verticies[3].x > pair.Shape.Verticies[0].x && col.Shape.Verticies[0].y < pair.Shape.Verticies[1].y && col.Shape.Verticies[1].y > pair.Shape.Verticies[0].y)
        {
            return true;
        }

        return false;
    }
}
