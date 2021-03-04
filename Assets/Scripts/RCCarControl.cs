using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCCarControl : MonoBehaviour
{
    [SerializeField] public WheelCollider[] m_WheelColliders = new WheelCollider[4];
    [SerializeField] public Transform[] m_Transforms = new Transform[4];
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public float maxSteerAngle = 30;
    public float motorForce = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void GetInput()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
        m_verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log(m_horizontalInput);
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        m_WheelColliders[0].steerAngle = m_steeringAngle;
        m_WheelColliders[1].steerAngle = m_steeringAngle;
        
    }
    private void Accelerate()
    {

    }
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;
        _collider.GetWorldPose(out _pos, out _quat);
        _transform.rotation = _quat;
        _transform.position = _pos;
    }
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(m_WheelColliders[0], m_Transforms[0]);
        UpdateWheelPose(m_WheelColliders[1], m_Transforms[1]);
        UpdateWheelPose(m_WheelColliders[2], m_Transforms[2]);
        UpdateWheelPose(m_WheelColliders[3], m_Transforms[3]);

    }
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();

    }

}
