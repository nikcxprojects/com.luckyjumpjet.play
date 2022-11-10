using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float m_Speed = 1;
    [SerializeField] private float m_XScale = 1;
    [SerializeField] private float m_YScale = 1;
 
    private Vector3 m_Pivot;
    private Vector3 m_PivotOffset;
    private float m_Phase;
    private bool m_Invert;
    private float m_2PI = Mathf.PI * 2;
 
    void Start() {
        m_Pivot = transform.position;
    }
 
    void Update () {
        m_PivotOffset = Vector3.up * 2 * m_YScale;
   
        m_Phase += m_Speed * Time.deltaTime;
        if(m_Phase > m_2PI)
        {
            m_Invert = !m_Invert;
            m_Phase -= m_2PI;
        }
        if(m_Phase < 0) m_Phase += m_2PI;
   
        transform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
        var x = transform.position.x;
        var y = transform.position.y;
        x += Mathf.Sin(m_Phase) * m_XScale;
        y += Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_YScale;
        transform.position = new Vector2(x, y);
    }

}
