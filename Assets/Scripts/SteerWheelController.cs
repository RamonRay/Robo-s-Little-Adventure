using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerWheelController : MonoBehaviour
{
    private Transform m_transform;
    public Transform dotTransform;
    public Transform axisTransform;
    private float steerAngle;
    private Quaternion initRotation;
    private Vector3 initVector;
    private Vector3 currentVector;
    private Vector3 axisVector;
    public UnityStandardAssets.Vehicles.Car.CarUserControl carUserControl;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = gameObject.transform;
        initRotation = transform.rotation;
        ResetPose();
        StartCoroutine("PrintAngle");
    }
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ResetPose();
        }
        SteerWheelUpdate();
        carUserControl.horizontal = steerAngle;
    }

    // Update is called once per frame

    public void SteerWheelUpdate()
    {
        axisVector = axisTransform.position - m_transform.position;
        //Current Dot Local Vector
        Vector3 _vec =  dotTransform.position-m_transform.position;
        _vec = _vec + Vector3.Dot(_vec, axisVector)*axisVector;
        _vec=_vec.normalized;
        steerAngle = Vector3.Angle(initVector, _vec);
        float _sign = Vector3.Dot(axisVector, Vector3.Cross(initVector, _vec));
        if(_sign<0)
        {
            steerAngle *= -1f;
        }
        Debug.Log(steerAngle);

    }
        
        
    
    public void ResetPose()
    {
        initVector = dotTransform.position - m_transform.position;
        axisVector = axisTransform.position - m_transform.position;
        steerAngle = 0f;
    }
    IEnumerator PrintAngle()
    {
        while(true)
        {
            Debug.Log(steerAngle);
            yield return new WaitForSeconds(1.0f);
        }
    }
    public float SteerAngle()
    {
        return steerAngle;
    }
}
