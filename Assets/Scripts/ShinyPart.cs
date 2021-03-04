using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyPart : MonoBehaviour
{
    public Vector3 AngularSpeed;
    public float height;
    public float floatPeriod;
    private Vector3 initPosition;
    private float m_x;
    private float m_y;
    private float m_z;
    private float currentY;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        initPosition = transform.position;
        m_x = initPosition.x;
        m_y = initPosition.y;
        m_z = initPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Float();
    }
    void Rotate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + AngularSpeed.x*Time.deltaTime, transform.localEulerAngles.y + AngularSpeed.y * Time.deltaTime, transform.localEulerAngles.z + AngularSpeed.z * Time.deltaTime);
    }
    void Float()
    {
        currentY = m_y + height * Mathf.Sin(time/ floatPeriod * 360*Mathf.Deg2Rad);
        time += Time.deltaTime;
        transform.position = new Vector3(m_x, currentY, m_z);
    }
}
