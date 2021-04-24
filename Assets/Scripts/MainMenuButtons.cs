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
    public static bool replayGame = false;

    public static bool easyMode = false;
    public static bool mediumMode = false;
    public static bool hardMode = false;

    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>(); ;
    }

    void FixedUpdate()
    {

    }

    public void easyModeSelection()
    {
        Debug.Log("Let's play");
        sfxMan.selection.Play();
        newGame = true;
        level1 = true;
        easyMode = true;
        SceneManager.LoadScene(loadScene);
    }

    public void mediumModeSelection()
    {
        Debug.Log("Let's play");
        sfxMan.selection.Play();
        newGame = true;
        level1 = true;
        mediumMode = true;
        SceneManager.LoadScene(loadScene);
    }

    public void hardModeSelection()
    {
        Debug.Log("Let's play");
        sfxMan.selection.Play();
        newGame = true;
        level1 = true;
        hardMode = true;
        SceneManager.LoadScene(loadScene);
    }

    public void ReplayGame()
    {
        Debug.Log("Let's play");
        sfxMan.selection.Play();
        newGame = false;
        replayGame = true;
        SceneManager.LoadScene("Stage Select");
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

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
