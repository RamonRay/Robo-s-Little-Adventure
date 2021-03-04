using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerAngle : MonoBehaviour
{
    public UnityStandardAssets.Vehicles.Car.CarUserControl carUserControl;
    private float steerAngle;

    public void FixedUpdate()
    {
        Horizontal();
    }
    public void Horizontal()
    {
        steerAngle=(transform.localRotation.eulerAngles.x)/180-1;
        Debug.Log(transform.localRotation.eulerAngles.x);
        carUserControl.horizontal = steerAngle;
    }
}
