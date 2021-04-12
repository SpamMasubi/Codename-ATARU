using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private SFXManager sfxMan;

    public string loadScene;

    public static bool newGame = false;
    public static bool level1 = false;

    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>(); ;
    }

    void FixedUpdate()
    {

    }

    public void startGame()
    {
        Debug.Log("Let's play");
        sfxMan.selection.Play();
        newGame = true;
        level1 = true;
        SceneManager.LoadScene(loadScene);
    }

    public void ReplayGame()
    {
        Debug.Log("Let's play");
        sfxMan.selection.Play();
        newGame = false;
        //SceneManager.LoadScene(loadScene);
    }

    public void QuitGame()
    {
        Debug.Log("Thanks for playing! Good bye");
        sfxMan.selection.Play();
        Application.Quit();
    }

    public void EndCredits()
    {
        Debug.Log("Credits");
        sfxMan.selection.Play();
        MusicController.musicCanPlay = false;
        SceneManager.LoadScene("Credit Scene");
    }
}
