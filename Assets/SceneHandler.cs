using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "StartGame")
        {
            Debug.Log("GameStart");
            SceneManager.LoadScene("Game");
            
        }
        else if (e.target.name == "Help")
        {
            Debug.Log("Help");
            SceneManager.LoadScene("HelpMenu");
        }
        else if(e.target.name=="Exit")
        {
            Debug.Log("Exit");
            Application.Quit();
        }
        else if(e.target.name=="MainMenu")
        {
            Debug.Log("Menu");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "StartGame")
        {
            Debug.Log("GameStart was entered");

        }
        else if (e.target.name == "ResetPosition")
        {
            Debug.Log("PositionReset was entered");
        }
        else if (e.target.name == "Exit")
        {
            Debug.Log("Exit was entered");

        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "StartGame")
        {
            Debug.Log("GameStart was exited");

        }
        else if (e.target.name == "ResetPosition")
        {
            Debug.Log("PositionReset was exited");
        }
        else if (e.target.name == "Exit")
        {
            Debug.Log("Exit was exited");
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(1);
        }
    }
}