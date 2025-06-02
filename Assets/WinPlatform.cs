using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPlatform : MonoBehaviour
{
    private BallClimbControls controls;
    public AstrollManager manager;
    public GameObject winscreen;
    public Text winTime;
    bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        //controls = manager.controls;
    }

    // Update is called once per frame
    void Update()
    {
        if(won && controls.UI.Submit.ReadValue<float>() > 0.5f)
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !won)
        {
            controls = manager.controls;
            winscreen.SetActive(true);
            //float time = Time.timeSinceLevelLoad;
            int hours = 0;
            int minutes = (int)Time.timeSinceLevelLoad / 60; // minutes is the integer part of seconds/60
            while (minutes > 60)
            {
                hours++;
                minutes -= 60;
            }
            int seconds = (int)Time.timeSinceLevelLoad % 60; // % is the "modulo" or "remainder" operator
            string secondsBetween = ":";
            if (seconds < 10)
                secondsBetween = ":0";
            string minutesBetween = ":";
            if (minutes < 10)
                minutesBetween = ":0";
            winTime.text = hours + minutesBetween + minutes + secondsBetween + seconds;
            controls.Gameplay.Disable();
            controls.UI.Enable();
            won = true;
        }
    }
}
