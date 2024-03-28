using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleManager : MonoBehaviour
{
    [SerializeField] private UICollider[] m_colliders;

    private UICollisionManager m_manager = new();

    private void Start()
    {
        foreach (var col in m_colliders)
        {
            m_manager.RegisterCollider(col);
        }
    }
}
