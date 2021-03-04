using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class AZViewReset : MonoBehaviour
{

    public SteamVR_Action_Boolean resetButton;
    public SteamVR_Input_Sources handType;
    public bool test = false;
    public bool autoReset = true;

    public Transform centerTo;
    public Transform cameraRig;
    public Transform cameraItSelf;
    // Start is called before the first frame update
    void Start()
    {
        if(autoReset)
        {
            //Reset();
            StartCoroutine(deferReset());
        }
    }

    IEnumerator deferReset() {

        yield return new WaitForSeconds(0.1f);

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (resetButton.stateDown == true)
        {
            Reset();
        }
    }

    public void ResetView() {

        /* Valve.VR.OpenVR.System.ResetSeatedZeroPose();
         Valve.VR.OpenVR.Compositor.SetTrackingSpace(
         Valve.VR.ETrackingUniverseOrigin.TrackingUniverseSeated);*/

        SteamVR.instance.hmd.ResetSeatedZeroPose();
        InputTracking.Recenter();
    }

    public void Reset()
    {
        ResetView();
        Vector3 delta = centerTo.position - cameraItSelf.position;
        cameraRig.position += delta;

        test = true;
    }
}
