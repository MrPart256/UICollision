using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionDetection
{
    public abstract bool Resolve(UICollider col, UICollider pair);
}
