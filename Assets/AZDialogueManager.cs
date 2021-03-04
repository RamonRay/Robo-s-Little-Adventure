using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AZDialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class ScriptElement {

        public string text = "";
        public AudioClip audio = null;
        public float timer = 5;
    }


    [System.Serializable]
    public class Script {
        public ScriptElement[] scriptElements;
    }


    public Script[] scripts;
    public static AZDialogueManager instance;


    public AudioSource audioSource;
    public GameObject canvas;
    public Text text;
    public float displayTime = 0f;
    public float minDisplayTime = 2f;
    private int index;
    private int showingText;
    private float lastShowTime;
    private Queue<ScriptElement> queuedDialogues;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        canvas.SetActive(false);
        index = 0;
        showingText = 0;
        lastShowTime = Time.time;
        queuedDialogues = new Queue<ScriptElement>();
        StartCoroutine(deferStart());
    }

    public void FixedUpdate()
    {
        if (displayTime > 0)
        {
            displayTime -= Time.fixedDeltaTime;
            if (displayTime <= 0)
            {
                NextDialogue();
            }

        }
    }


    public void pushDialogue(string dialogueContent)
    {
        canvas.SetActive(true);

        ScriptElement temp = new ScriptElement();
        temp.text = dialogueContent;
        temp.timer = 5;
        queuedDialogues.Enqueue(temp);
        if (displayTime <= 0) { NextDialogue(); }

        // currentDialogues.Enqueue(dialogueContent);
        //StartCoroutine("ShowDialogue");
    }



    public void playScript(int i)
    {

        for (int j = 0; j < scripts[i].scriptElements.Length; j++)
        {
            queuedDialogues.Enqueue(scripts[i].scriptElements[j]);

        }
        if (displayTime <= 0) { NextDialogue(); }
    }

    public void NextDialogue() {
        if (queuedDialogues.Count <= 0) {
            canvas.SetActive(false);
            return; }

        canvas.SetActive(true);
        ScriptElement temp = queuedDialogues.Dequeue();
        text.text = temp.text;
        displayTime = temp.timer;
        if (displayTime < 0.01f) { displayTime = 0.01f; }
        if (temp.audio != null) {
            audioSource.clip = temp.audio;
            audioSource.Play();
        }

    }

    IEnumerator deferStart() {




        yield return new WaitForSeconds(1);


        playScript(0);
    }

    //Deprecated
   /* IEnumerator ShowDialogue()
    {
        showingText++;
        if (showingText > 1)
        {
            yield return new WaitForSeconds(Mathf.Max(0f, (float)(showingText - 1) * minDisplayTime - Time.time + lastShowTime));
        }
        canvas.SetActive(true);
        text.text = queuedDialogues.Dequeue().text;
        lastShowTime = Time.time;

        yield return new WaitForSeconds(displayTime);

        showingText--;
        if(showingText==0)
        {
            canvas.SetActive(false);
        }
        yield return 0;
    }*/


    
}
