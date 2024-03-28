using UnityEngine;
using UnityEngine.UI;

public sealed class RectangularShape : Shape
{
    public RectangularShape(RectTransform r, CanvasScaler scaler) : base(scaler)
    {
        m_rect = r;
    }

    public override Vector2[] Verticies
    {
        get
        {
            return new Vector2[] { m_bottomLeft, m_topLeft, m_topRight, m_bottomRight };
        }
    }

    private Vector2 m_bottomLeft
    {
        get
        {
            Vector2 botLeft = Vector2.zero;

            botLeft.x = m_rect.position.x + m_rect.rect.center.x - m_rect.rect.width / 2 * m_scaler.transform.lossyScale.x;
            botLeft.y = m_rect.position.y + m_rect.rect.center.y - m_rect.rect.height / 2 * m_scaler.transform.lossyScale.y;

            return botLeft;
        }
    }
    private Vector2 m_bottomRight
    {
        get
        {
            Vector2 botRight = Vector2.zero;

            botRight.x = m_rect.position.x + m_rect.rect.center.x + m_rect.rect.width / 2 * m_scaler.transform.lossyScale.x;
            botRight.y = m_rect.position.y + m_rect.rect.center.y - m_rect.rect.height / 2 * m_scaler.transform.lossyScale.y;

            return botRight;
        }
    }
    private Vector2 m_topLeft
    {
        get
        {
            Vector2 topLeft = Vector2.zero;

            topLeft.x = m_rect.position.x + m_rect.rect.center.x - m_rect.rect.width / 2 * m_scaler.transform.lossyScale.x;
            topLeft.y = m_rect.position.y + m_rect.rect.center.y + m_rect.rect.height / 2 * m_scaler.transform.lossyScale.y;

            return topLeft;
        }
    }
    private Vector2 m_topRight
    {
        get
        {
            Vector2 topRight = Vector2.zero;

            topRight.x = m_rect.position.x + m_rect.rect.center.x + m_rect.rect.width / 2 * m_scaler.transform.lossyScale.x;
            topRight.y = m_rect.position.y + m_rect.rect.center.y + m_rect.rect.height / 2 * m_scaler.transform.lossyScale.y;

            return topRight;
        }
    }

    private RectTransform m_rect;
}
