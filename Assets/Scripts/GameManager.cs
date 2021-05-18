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

    public GameObject bossDialogue;
    public Animator anim;

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
                if (MainMenuButtons.newGame && !playAgain || playAgain || MainMenuButtons.replayGame)
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

#if UNITY_ANDROID || UNITY_IOS
                //shoot button display
                shootButton.SetActive(true);
                missilesButton.SetActive(true);

                //display joystick
                JoystickOuter.SetActive(true);
                JoystickInner.SetActive(true);
#endif
                //Start Game based on user's chose of gameplay mode
                if (MainMenuButtons.easyMode)
                {
                    //start enemy spawner
                    if (MainMenuButtons.level1 || StageSelect.replayLevel1)
                    {
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 10;
                    }
                    else if (AttackHeliBoss.isBossDead || StageSelect.replayLevel2)
                    {
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 20;
                    }
                    else if (StealthFighterBoss.isBossDead || StageSelect.replayLevel3)
                    {
                        EnemyMiGSpawner.maxSpawnRateInSeconds = 5.0f;
                        EnemySukhoiSpawner.maxSpawnRateInSeconds = 7.0f;
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 30;
                    }
                }
                else if (MainMenuButtons.mediumMode)
                {
                    //start enemy spawner
                    if (MainMenuButtons.level1 || StageSelect.replayLevel1)
                    {
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 20;
                    }
                    else if (AttackHeliBoss.isBossDead || StageSelect.replayLevel2)
                    {
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 30;
                    }
                    else if (StealthFighterBoss.isBossDead || StageSelect.replayLevel3)
                    {
                        EnemyMiGSpawner.maxSpawnRateInSeconds = 5.0f;
                        EnemySukhoiSpawner.maxSpawnRateInSeconds = 7.0f;
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 40;
                    }
                }
                else if (MainMenuButtons.hardMode)
                {
                    //start enemy spawner
                    if (MainMenuButtons.level1 || StageSelect.replayLevel1)
                    {
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 30;
                    }
                    else if (AttackHeliBoss.isBossDead || StageSelect.replayLevel2)
                    {
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 40;
                    }
                    else if (StealthFighterBoss.isBossDead || StageSelect.replayLevel3)
                    {
                        EnemyMiGSpawner.maxSpawnRateInSeconds = 5.0f;
                        EnemySukhoiSpawner.maxSpawnRateInSeconds = 7.0f;
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 50;
                    }
                }
                else //default gameplay mode
                {
                    //start enemy spawner
                    if (MainMenuButtons.level1 || StageSelect.replayLevel1)
                    {
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 20;
                    }
                    else if (AttackHeliBoss.isBossDead || StageSelect.replayLevel2)
                    {
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 30;
                    }
                    else if (StealthFighterBoss.isBossDead || StageSelect.replayLevel3)
                    {
                        EnemyMiGSpawner.maxSpawnRateInSeconds = 5.0f;
                        EnemySukhoiSpawner.maxSpawnRateInSeconds = 7.0f;
                        enemySpawner.GetComponent<EnemyMiGSpawner>().ScheduleEnemySpawner();
                        secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().ScheduleEnemySpawner();
                        cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                        //start the killCount
                        EnemyKillCountObj.GetComponent<EnemyKillCount>().KillCount = 40;
                    }
                }

                break;

            case GameManagerState.Boss:

                //Stop enemy spawner
                enemySpawner.GetComponent<EnemyMiGSpawner>().UnscheduleEnemySpawner();
                cargoSpawner.GetComponent<EnemyCargoSpawner>().ScheduleEnemySpawner();
                secondFighterSpawner.GetComponent<EnemySukhoiSpawner>().UnscheduleEnemySpawner();

                rightWall.SetActive(true);
                leftWall.SetActive(true);

                sfx.dialogue.Play();
                //start enemy spawner
                if (MainMenuButtons.level1 || StageSelect.replayLevel1)
                {
                    newTrack = 3;
                    theMC.SwitchTrack(newTrack);
                    sfx.firstBossVoice.Play();
                    StartCoroutine(startBossDialogue());
                    heliBoss.SetActive(true);
                }
                else if (AttackHeliBoss.isBossDead || StageSelect.replayLevel2)
                {
                    newTrack = 3;
                    theMC.SwitchTrack(newTrack);
                    sfx.secondBossVoice.Play();
                    StartCoroutine(startBossDialogue());
                    stealthFighterBoss.SetActive(true);
                }
                else if (StealthFighterBoss.isBossDead || StageSelect.replayLevel3)
                {
                    newTrack = 5;
                    theMC.SwitchTrack(newTrack);
                    sfx.KarmovVoice.Play();
                    StartCoroutine(startBossDialogue());
                    finalBoss.SetActive(true);
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
                if (MainMenuButtons.level1 || StageSelect.replayLevel1)
                {
                    heliBoss.SetActive(false);
                    newTrack = 0;
                    theMC.SwitchTrack(newTrack);
                }
                else if (AttackHeliBoss.isBossDead || StageSelect.replayLevel2)
                {
                    stealthFighterBoss.SetActive(false);
                    newTrack = 2;
                    theMC.SwitchTrack(newTrack);
                }
                else if (StealthFighterBoss.isBossDead || StageSelect.replayLevel3)
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

#if UNITY_ANDROID || UNITY_IOS
                //shoot button display
                shootButton.SetActive(false);
                missilesButton.SetActive(false);
#endif

                EnemyKillCount.canStartBoss = false;
                AttackHeliBoss.startBoss = false;
                StealthFighterBoss.startBoss = false;
                FlyingFortress.startBoss = false;

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

#if UNITY_ANDROID || UNITY_IOS
                //hide joystick
                JoystickOuter.SetActive(false);
                JoystickInner.SetActive(false);
#endif

                //shoot button display
                shootButton.SetActive(false);
                missilesButton.SetActive(false);
                StartCoroutine(setNextButtonActive());

                EnemyKillCount.canStartBoss = false;
                MainMenuButtons.newGame = false;
                AttackHeliBoss.startBoss = false;
                StealthFighterBoss.startBoss = false;
                FlyingFortress.startBoss = false;

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

    public void GameOverContinueGame()//In game over state, if player chooses to continue the game
    {
        sfx.selection.Play();
        gameOverStart.SetActive(false);
        ChangeToOpeningState();
    }

    public void GameOverQuitGame() //In game over state, if player chooses to quit game
    {
        sfx.selection.Play();
        MainMenuButtons.newGame = false;
        MainMenuButtons.level1 = false;
        MainMenuButtons.replayGame = false;
        MusicController.musicCanPlay = true;
        MainMenuButtons.easyMode = false;
        MainMenuButtons.mediumMode = false;
        MainMenuButtons.hardMode = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void NextLevel() //Change to next scene
    {
        if (MainMenuButtons.replayGame)
        {
            sfx.selection.Play();
            gameWinStart.SetActive(false);
            SceneManager.LoadScene("Stage Select");
            MusicController.musicCanPlay = true;
            StageSelect.replayLevel1 = false;
            StageSelect.replayLevel2 = false;
            StageSelect.replayLevel3 = false;
            StealthFighterBoss.isBossDead = false;
            AttackHeliBoss.isBossDead = false;
        }
        else
        {
            sfx.selection.Play();
            gameWinStart.SetActive(false);
            SceneManager.LoadScene(loadScene);
            MusicController.musicCanPlay = true;
        }
    }

    public IEnumerator setNextButtonActive()
    {
        yield return new WaitForSeconds(8.0f);
        nextLevel.SetActive(true);
    }

    public IEnumerator startBossDialogue()
    {
        bossDialogue.SetActive(true);
        anim.SetBool("isOpen", true);
        yield return new WaitForSeconds(6.0f);
        anim.SetBool("isOpen", false);
        yield return new WaitForSeconds(1.0f);
        bossDialogue.SetActive(false);
    }
}
