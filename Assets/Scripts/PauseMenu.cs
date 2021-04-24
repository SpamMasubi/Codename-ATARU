using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private SFXManager sfxMan;

    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>(); ;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        MusicController.musicPause = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        MusicController.musicPause = true;
    }

    public void LoadMainMenu()
    {
        if (MainMenuButtons.replayGame)
        {
            Time.timeScale = 1f;
            MusicController.musicCanPlay = true;
            sfxMan.selection.Play();
            SceneManager.LoadScene("Stage Select");
            MusicController.musicPause = false;
            StageSelect.replayLevel1 = false;
            StageSelect.replayLevel2 = false;
            StageSelect.replayLevel3 = false;
            EnemyKillCount.canStartBoss = false;
            AttackHeliBoss.startBoss = false;
            StealthFighterBoss.startBoss = false;
            FlyingFortress.startBoss = false;
        }
        else
        {
            Time.timeScale = 1f;
            MusicController.musicCanPlay = true;
            sfxMan.selection.Play();
            SceneManager.LoadScene("Main Menu");
            MusicController.musicPause = false;
            MainMenuButtons.newGame = false;
            EnemyKillCount.canStartBoss = false;
            AttackHeliBoss.startBoss = false;
            StealthFighterBoss.startBoss = false;
            FlyingFortress.startBoss = false;
            MainMenuButtons.easyMode = false;
            MainMenuButtons.mediumMode = false;
            MainMenuButtons.hardMode = false;
        }
    }
}
