using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Security.Cryptography;

public class UICollisionManager
{
    public UICollisionManager()
    {
        m_hash = new(10, 10);

        m_hash.Init(Screen.width, Screen.height);
    }

    private RectCollisionDetection m_collisionDetection = new();

    private readonly CollisionHash m_hash;

    public void RegisterCollider(UICollider collider)
    {
        RegisterColliderRecievers(collider);

        collider.Manager = this;

        m_hash.Insert(collider.transform.position, collider);
    }

    public void HandleCollision(UICollider collider)
    {
        m_hash.UpdatePosition(collider.transform.position, collider);
        
        var neighbours = m_hash.QueryPosition(collider.transform.position);

        foreach (var other in neighbours)
        {
            if (other == collider)
                continue;
            if (m_collisionDetection.Resolve(other, collider))
            {
                other.RecieveCollision(collider);
                collider.RecieveCollision(other);
            }
        }
    }

    public void RemoveCollider(UICollider collider)
    {
        collider.Recievers.Clear();

        collider.Manager = null;

        m_hash.Remove(collider.transform.position, collider);

    }

    private void RegisterColliderRecievers(UICollider col)
    {
        List<MonoBehaviour> potentialRecievers = col.gameObject.GetComponentsInChildren<MonoBehaviour>().ToList();

        foreach (MonoBehaviour potentialReciever in potentialRecievers)
        {
            Type recieverType = potentialReciever.GetType();

            var method = recieverType.GetMethod("OnUICollision", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (method != null)
            {
                col.Recievers.Add(potentialReciever, method);
            }
        }
    }
}
