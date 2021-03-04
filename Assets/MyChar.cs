using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChar : MonoBehaviour
{

    public int hp = 100;
    public int maxHp = 100;
    public float score = 0;



    public UnityEngine.UI.Text displayText;
    public GameObject[] HPObjects;
    public Material hpIndicatorOn;
    public Material hpIndicatorOff;
    public GameObject player;

    public AZGameManager gameManager;

    public AudioClip loseLifeSFX;
    private AudioSource loseLifeAudio;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The Mychar script is in"+gameObject.name);
        hp = HPObjects.Length;
        for(int i=0;i<hp;i++)
        {
            Renderer _renderer = HPObjects[i].GetComponent<Renderer>();
            _renderer.material = hpIndicatorOn;
        }
        loseLifeAudio = AddSFXtoPlayer(loseLifeSFX);
        loseLifeAudio.playOnAwake = false;

    }

    private void OnEnable()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
    }

    public void OnHeal(int value)
    {
        if (hp <=0) { return; }
        hp += value;
        if (hp > maxHp) { hp = maxHp; }
    }

    public bool OnHurt(int damage, MyChar damager)
    {
        //If is dodging then no damage,
        if (hp > 0)
        {
            int originHP = hp;
            hp -= damage;
           // this.GetComponent<Animator>().SetBool("Hurt", true);
           for (; originHP>hp;originHP--)
            {
                Renderer _renderer = HPObjects[originHP - 1].GetComponent<Renderer>();
                _renderer.material = hpIndicatorOff;
            }
            loseLifeAudio.Play();
            if (hp <= 0)
            {
                gameManager.GameOver();   
            }

        }

        return true;
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
        source.time = UnityEngine.Random.Range(0f, sfx.length);
        source.minDistance = 1;
        source.maxDistance = 10;
        source.dopplerLevel = 0;
        return source;
    }

}
