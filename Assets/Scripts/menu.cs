using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Button playerNameButton;
    public TMP_InputField playerNameInput;
   

    void Awake()
    {
       
    }
    void Start()
    {

    }
    public void BallClimb()
    {
        print("BallClimb Selected.");
        SceneManager.LoadScene("BallClimb");
    }

    public void QuitingGame()
    {
        print("Quit Game was clicked");
        Application.Quit();
    }
}
