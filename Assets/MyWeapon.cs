using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeapon : MonoBehaviour
{
    public int damage = 50;
    public string damageTag = "Enemy";
    public AudioClip triggerSound;
    public GameObject audioSource;
    public MyChar myCharacter;
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
        var ec = other.gameObject.GetComponent<MyChar>();
        string tag = other.gameObject.tag;
        if (tag == damageTag && ec!= null)
        {

            bool result  = ec.OnHurt(damage,myCharacter);

            //If hitted?
            if (result)
            {
                if (triggerSound != null)
                {
                    GameObject audioObject = null;
                    audioObject = Instantiate(audioSource.gameObject, this.transform.position, Quaternion.identity) as GameObject;

                    var source = audioObject.gameObject.GetComponent<AudioSource>();

                    source.PlayOneShot(triggerSound);

                }

                //Camera.main.GetComponent<CameraShake>().startShaking(0.1f);

            }
            
        }
    }

}
