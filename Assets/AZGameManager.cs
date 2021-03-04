using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using UnityEngine.AI;

public class AZGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasTorsol = false;
    public bool hasLegs = false;
    public bool hasArms = false;
    public bool hasKey = false;

    public static bool inGame = false;

    public float fadeTime=3f;
    public GameObject tracker;


    public GameObject dog;
    public GameObject[] roboGameObjects;
    public GameObject completeGameobject;
    public UnityStandardAssets.Vehicles.Car.CarUserControl carUserControl;
    private bool isComplete = false;

    public GameObject player;
    public AudioClip backGroundMusic;
    public AudioClip transitionSFX;
    public AudioClip intenseBGM;
    public AudioClip winSFX;
    public AudioClip loseSFX;
    private AudioSource intenseSFX;

    private AudioSource bgmSource;

    private void Awake()
    {
        //DontDestroyOnLoad(tracker);
    }

    void Start()
    {
        UpdateStatus();
        carUserControl.enabled = true;
        bgmSource=AddSFXtoPlayer(backGroundMusic);
        bgmSource.loop = true;
        isComplete = false;
        dog.SetActive(false);
        inGame = true;
    }

    // Update is called once per frame
    void Update()
    {

     


    }

    public void UpdateStatus() {
        foreach (var o in roboGameObjects) { o.SetActive(false); }
        if (hasTorsol == false)
        {
            roboGameObjects[4].SetActive(true);
        }
        else if (hasArms == false)
        {
            roboGameObjects[3].SetActive(true);
        }
        else if (hasLegs == false)
        {
            roboGameObjects[2].SetActive(true);
        }
        else if (hasKey == false)
        {
            roboGameObjects[1].SetActive(true);
        }
        else
        {
            roboGameObjects[0].SetActive(true);
        }


    }


    public void getTorsol() { hasTorsol = true; UpdateStatus(); }

    public void getLegs() { hasLegs = true; UpdateStatus(); }

    public void getArms() { hasArms = true; UpdateStatus(); }

    public void getKey() { hasKey = true; UpdateStatus(); }

    //Function called when player reached the final destination
    public void GameComplete()
    {
        if (hasKey&&!isComplete)
        {
            inGame = false;
            //TrackedObject.instance.enabled = false;
            isComplete = true;
            AddSFXtoPlayer(winSFX);
            if (intenseSFX != null) { intenseSFX.Stop(); }
            
            StartCoroutine("WinFade");
        }
    }


    public void GameOver()
    {
        if (!isComplete)
        {
            isComplete = true;
            //TrackedObject.instance.enabled = false;
            AddSFXtoPlayer(loseSFX);
            if (intenseSFX != null)
            {
                intenseSFX.Stop();
            }
            else
            {
                //bgmSource.Stop();
            }
            //Stop car
            carUserControl.enabled = false;
            inGame = false;
            StartCoroutine("LoseFade");
        }

    }

    //Fade to black and EndGame
    IEnumerator LoseFade()
    {
        SteamVR_Fade.Start(Color.clear, 0f);
        SteamVR_Fade.Start(Color.black, fadeTime);
        yield return new WaitForSeconds(Mathf.Max(fadeTime,loseSFX.length));
        SceneManager.LoadScene("GameOver");
        yield return 0;
    }
    //Fade to white and win the game
    IEnumerator WinFade()
    {
        SteamVR_Fade.Start(Color.clear, 0f);
        SteamVR_Fade.Start(Color.white, fadeTime);
        yield return new WaitForSeconds(Mathf.Max(fadeTime,winSFX.length));
        SceneManager.LoadScene("Congratulation");
        yield return 0;

    }

    //Call this funtion when the dog should come out
    public void DogShowUp()
    {
        dog.SetActive(true);
        intenseSFX = AddSFXtoPlayer(transitionSFX);
        StartCoroutine("BGMTransition");
        Destroy(bgmSource);
    }
    IEnumerator BGMTransition()
    {
        yield return new WaitForSeconds(26f);
        intenseSFX.Stop();
        intenseSFX = AddSFXtoPlayer(intenseBGM);
        yield return 0;
    }
    public void DogSpeedUp(float speed)
    {
        NavMeshAgent dogAgent = dog.GetComponent<NavMeshAgent>();
        dogAgent.speed = speed;
    }

    private AudioSource AddSFXtoPlayer(AudioClip sfx)
    {
        // create the new audio source component on the game object and set up its properties
        AudioSource source = player.AddComponent<AudioSource>();
        source.clip = sfx;
        source.volume = 1;
        source.loop = false;
        source.pitch = 1;

        // start the clip from a random point
        source.time = 0f;
        source.Play();
        source.minDistance = 1;
        source.maxDistance = 10;
        source.dopplerLevel = 0;
        return source;
    }

}
