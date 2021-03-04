using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTalk : MonoBehaviour
{
    public Material mat;
    private float endTime;
    public float blinkTime=1f;
    public Transform player;
    private Vector3 lookAtPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        print(mat.name);
        mat.SetColor("_EmissionColor", Color.black);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Chat(20f);
        }
        lookAtPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookAtPosition);
    }

    public void Chat(float time)
    {
        endTime = time + Time.time;
        StartCoroutine("Blink");
    }
    IEnumerator Blink()
    {
        while(Time.time<endTime)
        {
            mat.SetColor("_EmissionColor", Color.white);
            yield return new WaitForSeconds(Random.Range(0.5f * blinkTime, blinkTime));
            mat.SetColor("_EmissionColor", Color.black);
            yield return new WaitForSeconds(Random.Range(0.5f * blinkTime, blinkTime));
            Debug.Log("Blink");
        }
        mat.SetColor("_Emission", Color.black);
        yield return 0;
    }

}
[SerializeField]
public class DialogueMessage
{
    public string message;
    public float showTime;
}
