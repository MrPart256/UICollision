using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class UICollider : MonoBehaviour
{
    public Dictionary<MonoBehaviour, MethodInfo> Recievers
    {
        get
        {
            return m_recievers;
        }
        set
        {
            m_recievers = value;
        }
    }
    public Shape Shape => m_shape;
    public UICollisionManager Manager
    {
        get
        {
            return m_manager;
        }
        set
        {
            m_manager = value;
        }
    }

    protected Shape m_shape;

    private Dictionary<MonoBehaviour, MethodInfo> m_recievers = new();
    private UICollisionManager m_manager;

    private Vector3 m_previousPosition;

    private void OnDisable()
    {
        m_manager.RemoveCollider(this);
    }

    private bool NeedUpdate()
    {
        return m_previousPosition != transform.position;
    }

    private void FixedUpdate()
    {
        RequestUpdate();
    }

    private void RequestUpdate()
    {
        if (NeedUpdate())
        {
            m_manager.HandleCollision(this);
            m_previousPosition = transform.position;
        }
    }

    public void RecieveCollision(UICollider col)
    {
        foreach (var reciever in m_recievers)
        {
            reciever.Value.Invoke(reciever.Key, new[] { col });
        }
    }
}
