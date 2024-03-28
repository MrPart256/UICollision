using UnityEngine;
using UnityEngine.UI;

public sealed class RectangularUICollider : UICollider
{
    private void OnValidate()
    {
        m_shape = new RectangularShape((RectTransform)transform, transform.root.GetComponent<CanvasScaler>());
    }
}
