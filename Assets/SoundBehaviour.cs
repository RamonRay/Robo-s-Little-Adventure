using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaviour : StateMachineBehaviour
{
    public GameObject audioSource;
    public List<AudioClip> sounds;
    public float triggerTime;
    private bool triggered;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        triggered = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime % 1 >= triggerTime && !triggered)
        {
           

            triggered = true;
            GameObject audioObject = null;
            if (audioSource != null)
                audioObject = Instantiate(audioSource.gameObject, animator.transform.position, Quaternion.identity) as GameObject;
          

            if (audioObject != null)
            {
                var source = audioObject.gameObject.GetComponent<AudioSource>();
                var clip = sounds[(int)Random.Range(0,sounds.Count)];
                source.PlayOneShot(clip);
            }
        }
    }
}
