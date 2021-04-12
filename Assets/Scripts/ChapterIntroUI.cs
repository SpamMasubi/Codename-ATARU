using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterIntroUI : MonoBehaviour
{
    private string levelToLoad;
    public GameObject chapterIntroUI;
    [SerializeField]
    private Text levelTitle;
    [SerializeField]
    private Text levelLocation;

    public GameObject startButton;
    public float startDelay = 5.0f;

    private SFXManager sfxMan;
    // Start is called before the first frame update
    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();
        MusicController.musicCanPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenuButtons.newGame)
        {
            
            levelTitle.text = "Level 1";
            levelLocation.text = "South Pacific";
            StartCoroutine(activeStart());
        }
        else if (AttackHeliBoss.isBossDead)
        {
            levelTitle.text = "Level 2";
            levelLocation.text = "Northern Siberia";
            StartCoroutine(activeStart());
        }
        else if (StealthFighterBoss.isBossDead)
        {
            levelTitle.text = "Level 3";
            levelLocation.text = "United Nation Headquarters";
            StartCoroutine(activeStart());
        }
    }

    public void startLevel()
    {
        sfxMan.selection.Play();
        MusicController.musicCanPlay = true;
        if (MainMenuButtons.newGame)
        {
            levelToLoad = "Level 1";
            SceneManager.LoadScene(levelToLoad);
            
            startButton.SetActive(false);
        }
        else if (AttackHeliBoss.isBossDead)
        {
            levelToLoad = "Level 2";
            SceneManager.LoadScene(levelToLoad);
            startButton.SetActive(false);
        }
        else if (StealthFighterBoss.isBossDead)
        {
            levelToLoad = "Level 3";
            SceneManager.LoadScene(levelToLoad);
            startButton.SetActive(false);
        }
    }

    public IEnumerator activeStart()
    {
        yield return new WaitForSeconds(startDelay);
        startButton.SetActive(true);
    }
}
