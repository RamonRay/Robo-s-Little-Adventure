using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SFXTime
{
    public AudioClip sfx;
    public float time;
    public AudioSource audioSource;
    public float volume;
    public float pitch;
}



public class RobotIdleSFX : MonoBehaviour
{
    public SFXTime[] SFXs;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var SFX in SFXs)
        {
            SFX.audioSource = SetUpEngineAudioSource(SFX);
            StartCoroutine(SFXLooping(SFX));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SFXLooping(SFXTime SFX)
    {
        while(true)
        {
            SFX.audioSource.Play();
            yield return new WaitForSeconds(SFX.time);
        }
    }
    private AudioSource SetUpEngineAudioSource(SFXTime sfx)
    {
        // create the new audio source component on the game object and set up its properties
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = sfx.sfx;
        source.volume = sfx.volume;
        source.loop = false;
        source.pitch = sfx.pitch;

        // start the clip from a random point
        source.time = UnityEngine.Random.Range(0f, sfx.sfx.length);
        source.Play();
        source.minDistance = 1;
        source.maxDistance = 10;
        source.dopplerLevel = 0;
        return source;
    }

}


