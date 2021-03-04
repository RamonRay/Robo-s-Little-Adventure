using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AZItemTrigger : MonoBehaviour
{
    public UnityEvent[] OnTriggeredEvents;
    public string targetTag = "Car";
    public bool disableAfterTriggered = true;
    public float minPitch = 0.5f;

    private AudioSource navigationSFX;
    private Transform player;
    private float pitch;

    private void Start()
    {
        navigationSFX = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Debug.Log(GameObject.FindWithTag("Player").name);
    }
    private void FixedUpdate()
    {
        SoundPitch();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {

            foreach (var e  in OnTriggeredEvents)
            {
                e.Invoke();
                Debug.Log("Done");
            }



            if(disableAfterTriggered)
            this.gameObject.SetActive(false);
        }

    }
    // increase the navigation sfx's pitch as player come closer
    private void SoundPitch()
    {
        pitch = Mathf.Max(minPitch,Mathf.Min(3f,80f/(Vector3.Distance(player.position, transform.position))));
        navigationSFX.pitch = pitch;
    }


}
