using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class AZSteerWheelController : MonoBehaviour
{

    public UnityStandardAssets.Vehicles.Car.CarUserControl carUserControl;
    public float horiz = 0;

    public SteamVR_Action_Boolean throttleButton;
    public SteamVR_Action_Boolean reverseButton;
    public SteamVR_Input_Sources handType;
    public bool throttle = false;
    // Start is called before the first frame update
    void Start()
    {
       // SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
        //SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (AZGameManager.inGame == false) { return; }

        var x = transform.rotation.x;
        var y = transform.rotation.y;
        var z = transform.rotation.z;
        var w = transform.rotation.w;


        //Classic roll/pitch/yaw value calculation algorithm found at https://answers.unity.com/questions/416169/finding-pitchrollyaw-from-quaternions.html
        float roll = Mathf.Atan2(2 * y * w + 2 * x * z, 1 - 2 * y * y - 2 * z * z) / Mathf.PI * 180;
        float pitch = Mathf.Atan2(2 * x * w + 2 * y * z, 1 - 2 * x * x - 2 * z * z) / Mathf.PI * 180;
        float yaw = Mathf.Asin(2 * x * y + 2 * z * w) / Mathf.PI * 180;
        horiz = yaw / 90f;

       carUserControl.horizontal = horiz;
        carUserControl.throttle = throttleButton.state;
        carUserControl.reverse = reverseButton.state;
        throttle = throttleButton.state;

    }


    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        throttle = false;
       
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        throttle =true;
     
    }
}
