using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    // Start is called before the first frame update

    public float angle;
    public float angularSpeed;
    public AudioSource doorOpenSFX;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        StartCoroutine("RotateDoor");
    }

    IEnumerator RotateDoor()
    {
        doorOpenSFX.Play();
        while(Mathf.Abs(transform.eulerAngles.y-angle)>0.01)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+angularSpeed*0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        doorOpenSFX.Stop();
        yield return 0;
    }
}
