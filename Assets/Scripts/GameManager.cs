using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Reference to our game objects
    public GameObject playButton;
    public GameObject playerJet;
    public GameObject enemySpawner;
    public GameObject cargoSpawner;
    public GameObject secondFighterSpawner;
    public GameObject GameOverObj;
    public GameObject GameWinObj;
    public GameObject EnemyKillCountObj;
    public GameObject TitleName;
    public GameObject shootButton;
    public GameObject missilesButton;
    public GameObject JoystickOuter;
    public GameObject JoystickInner;

    public GameObject heliBoss;
    public GameObject stealthFighterBoss;
    public GameObject finalBoss;
    public GameObject rightWall;
    public GameObject leftWall;

    public string loadScene;
    public GameObject nextLevel;
    public static bool playAgain = false;

    private SFXManager sfx;
    public GameObject gameOverStart;
    public GameObject gameWinStart;
    private MusicController theMC;
    private int newTrack;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        Boss,
        GameWin,
        GameOver,
    }

    GameManagerState GMState;
    // Start is called before the first frame update
    void Start()
    {
        theMC = FindObjectOfType<MusicController>();
        sfx = FindObjectOfType<SFXManager>();
        GMState = GameManagerState.Opening;
    }

    // Update game manager state
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                MusicController.musicCanPlay = true;
                //Hide Game Over 
                GameOverObj.SetActive(false);

                //Display the Game Title
                TitleName.SetActive(true);

                //Set play button visible
                playButton.SetActive(true);
                nextLevel.SetActive(false);

                break;
            case GameManagerState.Gameplay:

                //Hide the Game Title
                TitleName.SetActive(false);

                //reset points to zero
                if (MainMenuButtons.newGame && !playAgain || playAgain)
                {
                    //set the player active and init playerLives and inventory
                    playerJet.GetComponent<PlayerController>().Init();
                    playAgain = false;
                }
                else
                {
                    //set the player active and current playerLives and inventory
                    playerJet.GetComponent<PlayerController>().ContinueInit();
                    playAgain = false;
                }
                

                //hide play button on game play state
                playButton.SetActive(false);

                //shoot button display
                shootButton.SetActive(true);
                missilesButton.SetActive(true);

                //display joystick
                JoystickOuter.SetActive(true);
                JoystickInner.SetActive(true);

                //start enemy spawner
                if (MainMenuButtons.level1)
                {
                    enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                    cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                    //start the killCount
                    EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 20;
                }
                else if (AttackHeliBoss.isBossDead)
                {
                    secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                    cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                    //start the killCount
                    EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 30;
                }
                else if (StealthFighterBoss.isBossDead)
                {
                    enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                    secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                    cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                    //start the killCount
                    EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 40;
                }

                break;

            case GameManagerState.Boss:

                //Stop enemy spawner
                enemySpawner.GetComponent<EnemyMiGSpawner>().UnscheduleEnemySpawner();
                cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().UnscheduleEnemySpawner();

                rightWall.SetActive(true);
                leftWall.SetActive(true);
                //start enemy spawner
                if (MainMenuButtons.level1)
                {
                    newTrack = 3;
                    theMC.SwitchTrack(newTrack);
                    heliBoss.SetActive(true);
                }
                else if (AttackHeliBoss.isBossDead)
                {
                    newTrack = 3;
                    theMC.SwitchTrack(newTrack);
                    stealthFighterBoss.SetActive(true);
                }
                else if (StealthFighterBoss.isBossDead)
                {
                    finalBoss.SetActive(true);
                    newTrack = 5;
                    theMC.SwitchTrack(newTrack);
                }


                break;

            case GameManagerState.GameOver:

                gameOverStart.SetActive(true);
                //Stop enemy spawner
                enemySpawner.GetComponent<EnemyMiGSpawner>().UnscheduleEnemySpawner();
                cargoSpawner.GetComponent<EnemyCargoSpawner>().UnscheduleEnemySpawner();
                secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().UnscheduleEnemySpawner();

                rightWall.SetActive(false);
                leftWall.SetActive(false);
                if (MainMenuButtons.level1)
                {
                    heliBoss.SetActive(false);
                    newTrack = 0;
                    theMC.SwitchTrack(newTrack);
                }
                else if (AttackHeliBoss.isBossDead)
                {
                    stealthFighterBoss.SetActive(false);
                    newTrack = 2;
                    theMC.SwitchTrack(newTrack);
                }
                else if (StealthFighterBoss.isBossDead)
                {

                    finalBoss.SetActive(false);
                    newTrack = 4;
                    theMC.SwitchTrack(newTrack);
                }

                //Display game over
                GameOverObj.SetActive(true);
                sfx.gameOver.Play();
                MusicController.musicCanPlay = false;

                //hide joystick
                JoystickOuter.SetActive(false);
                JoystickInner.SetActive(false);

                //shoot button display
                shootButton.SetActive(false);
                missilesButton.SetActive(false);

                EnemyKillCount.canStartBoss = false;

                break;

            case GameManagerState.GameWin:

                gameWinStart.SetActive(true);
                //Stop enemy spawner
                enemySpawner.GetComponent<EnemyMiGSpawner>().UnscheduleEnemySpawner();
                cargoSpawner.GetComponent<EnemyCargoSpawner>().UnscheduleEnemySpawner();
                secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().UnscheduleEnemySpawner();

                rightWall.SetActive(false);
                leftWall.SetActive(false);

                //Display game Win
                GameWinObj.SetActive(true);
                playerJet.SetActive(false);
                MusicController.musicCanPlay = false;

                //hide joystick
                JoystickOuter.SetActive(false);
                JoystickInner.SetActive(false);

                //shoot button display
                shootButton.SetActive(false);
                missilesButton.SetActive(false);
                StartCoroutine(setNextButtonActive());

                EnemyKillCount.canStartBoss = false;
                MainMenuButtons.newGame = false;

                break;
        }
    }

    //Function to set game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //Our player button will call this function when user clicks on it
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //Function to change game manager to opening state
    public void ChangeToOpeningState()
    {
        playAgain = true;
        SetGameManagerState(GameManagerState.Opening);
    }

    public void GameOverContinueGame()
    {
        sfx.selection.Play();
        gameOverStart.SetActive(false);
        ChangeToOpeningState();
    }

    public void GameOverQuitGame()
    {
        sfx.selection.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void NextLevel()
    {
        sfx.selection.Play();
        gameWinStart.SetActive(false);
        SceneManager.LoadScene(loadScene);
        MusicController.musicCanPlay = true;
    }

    public IEnumerator setNextButtonActive()
    {
        yield return new WaitForSeconds(8.0f);
        nextLevel.SetActive(true);
    }
}
