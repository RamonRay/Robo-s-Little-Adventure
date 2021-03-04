using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform carTransform;
    public Transform player;
    public Transform driverSeat;
    public Transform driverLookAt;
    private Vector3 initForward;
    private Vector3 offset= Vector3.zero;
    public float damping = 6.0f;
    public bool followTarget = false;
    void Start()
    {
        ResetPosition();
        Debug.Log(player.position);
        Debug.Log(player.forward);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetPosition();
        }
        
        //if ((lookAtPosition - transform.position) != Vector3.zero)
        {
           
        }


       


        if (followTarget) { this.transform.position = driverSeat.position; }
    }

    public void FixedUpdate()
    {
        Vector3 lookAtPosition = this.transform.position + new Vector3(carTransform.forward.x, 0, carTransform.forward.z);
        Quaternion rotation = Quaternion.LookRotation(lookAtPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * damping);
    }

    //Reset the position so that the player will be sitting right behind steering wheel at his current position and direction
    public void ResetPosition()
    {

        offset = player.position - transform.position;
        transform.position = transform.position - offset;
        initForward = player.forward;
        
    }

}
