using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerWheelRotation : MonoBehaviour
{
    public UnityStandardAssets.Vehicles.Car.CarUserControl carUserControl;
    float steerAngle;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void FixedUpdate()
    {
        steerAngle = carUserControl.horizontal *180;
        transform.localRotation = Quaternion.Euler(steerAngle+180, 0, 0);
        //transform.rotation = transform.parent.rotation; ;
        //transform.Rotate(this.transform.up,steerAngle + 180f);
    }
}
