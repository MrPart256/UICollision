using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleCollision : MonoBehaviour
{
    [SerializeField] private Image m_img;

    float currentAngle = 0;
    private void OnUICollision(UICollider col)
    {
        if (col == null)
        {
            m_img.color = Color.green;
        }
        else
        {
            m_img.color = Color.red;
        }
    }
}
