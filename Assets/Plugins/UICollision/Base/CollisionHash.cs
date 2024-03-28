using System.Collections.Generic;
using UnityEngine;
public class CollisionHash
{
    public CollisionHash(int columns, int rows)
    {
        m_columns = columns;
        m_rows = rows;
    }

    private readonly int m_columns;
    private readonly int m_rows;

    private float m_width;
    private float m_height;

    private float m_cellWidth;
    private float m_cellHeight;

    private Dictionary<int, List<UICollider>> m_dict = new();
    private Dictionary<UICollider, int> m_colliders = new();

    public void Init(float width, float height)
    {
        m_width = width;
        m_height = height;

        m_cellWidth = m_width / m_columns;
        m_cellHeight = m_height / m_rows;
    }

    public void Insert(Vector2 position, UICollider collider)
    {
        var key = Key(position);

        if (m_dict.ContainsKey(key))
        {
            m_dict[key].Add(collider);
        }
        else
        {
            m_dict[key] = new List<UICollider>() { collider };
        }

        m_colliders[collider] = key;
    }

    public void Remove(Vector2 position, UICollider collider)
    {
        if (m_colliders.ContainsKey(collider))
        {
            m_dict[m_colliders[collider]].Remove(collider);
        }
    }

    public void UpdatePosition(Vector2 position, UICollider collider)
    {
        Remove(position, collider);

        Insert(position, collider);
    }

    public List<UICollider> QueryPosition(Vector2 position)
    {
        var key = Key(position);
        return m_dict.ContainsKey(key) ? m_dict[key] : new();
    }

    private const int BIG_ENOUGH_INT = 16 * 1024;
    private const double BIG_ENOUGH_FLOOR = BIG_ENOUGH_INT + 0.0000;

    private static int FastFloor(float f)
    {
        return (int)(f + BIG_ENOUGH_FLOOR) - BIG_ENOUGH_INT;
    }

    private int Key(Vector3 v)
    {
        return (FastFloor(v.x / m_cellWidth) * 73856093) ^
                (FastFloor(v.y / m_cellHeight) * 19349663);
    }
}