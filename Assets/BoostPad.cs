using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public Rigidbody rb;
    public Transform carTransform;
    public float accelerationTime;
    public float acc;
    public bool changeDirection = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Car")
        {
            StartCoroutine("Acc");
        }
    }
    IEnumerator Acc()
    {
        int i = 0;
        int maxCount = (int)(accelerationTime * 100f);

        while (i <maxCount)
        {
            if (i < maxCount / 2 &&changeDirection)
            {
                Vector3 _lookAt = carTransform.position + transform.forward;
                rb.transform.LookAt(_lookAt);
            }
            rb.AddForce(acc*transform.forward, ForceMode.VelocityChange);
            yield return new WaitForSeconds(0.01f);
            i++;
        }

        yield return 0;
    }
}
