using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AZMainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public SteamVR_Action_Boolean startButton;
    public SteamVR_Input_Sources handType;
    public string sceneName = "Game";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startButton.stateDown == true)
        {
            PlayTheGame();

        }
    }
    public void PlayTheGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

    }
}
