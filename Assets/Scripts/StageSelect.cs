using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    private string stageName;

    public string mainMenu;

    private SFXManager sfxman;

    public GameObject description;

    public Text MissionTitle;
    public Text MissionDesc;

    public Animator anim;

    public static bool replayLevel1 = false;
    public static bool replayLevel2 = false;
    public static bool replayLevel3 = false;

    // Start is called before the first frame update
    void Start()
    {
        sfxman = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelOne()
    {
        sfxman.selection.Play();
        anim.SetBool("isOpen", false);
        anim.SetBool("isOpen", true);
        stageName = "Level 1";
        MissionTitle.text = "Mission #1";
        MissionDesc.text = "There has been activities of the Red Giant terrorists in the South Pacific. " +
            "MiG fighters are deployed to the location of the US Navy and our UN Task Force team on the USS Tomobiki. " +
            "We also have learned that they acquired a new American attack helicopter from a black market merchant. " +
            "Piloted by an elite helicopter pilot, the US Navy and Task Force won't stand a chance. " + 
            "Make your way to the South Pacific and eliminate the MiGs and the attack helicopter.";

    }

    public void LevelTwo()
    {
        sfxman.selection.Play();
        anim.SetBool("isOpen", false);
        anim.SetBool("isOpen", true);
        stageName = "Level 2";
        MissionTitle.text = "Mission #2";
        MissionDesc.text = "Our Russian allies have detect another Red Giant fleet in Northern Siberia. " +
            "Red Giant Sukhois are heading towards the Russian-UN Task Force joint military base. " +
            "All the units in the base are on high alert for potential terrorist attacks. " +
            "Another purchase of a stolen Russian stealth fighter made by the Red Giant from the same merchant. " +
            "This fighter is piloted by a defector whom joined the ranks of the terrorists. " +
            "Destroy that stealth fighter and the enemy Sukhois in the area.";
    }

    public void LevelThree()
    {
        sfxman.selection.Play();
        anim.SetBool("isOpen", false);
        anim.SetBool("isOpen", true);
        stageName = "Level 3";
        MissionTitle.text = "Mission #3";
        MissionDesc.text = "A final assault of the Red Giant terrorists. " +
            "They have made their way to the United Nation Headquarters where they are going to take the council members hostages. " +
            "Under the command of General Karmov in a flying super fortress, the Red Giant have deployed all their MiGs and Sukhoi fleets. " +
            "If the United Nation members are not saved in time, it will be an international catastrophe. " +
            "Eliminate General Karmov and save the world leaders from their diabolical scheme of world domination.";
    }
    
    public void startLevel()
    {
        if (stageName == "Level 1")
        {
            sfxman.selection.Play();
            SceneManager.LoadScene(stageName);
            replayLevel1 = true;
            anim.SetBool("isOpen", false);
        }
        else if (stageName == "Level 2")
        {
            sfxman.selection.Play();
            SceneManager.LoadScene(stageName);
            replayLevel2 = true;
            anim.SetBool("isOpen", false);
        }
        else if (stageName == "Level 3")
        {
            sfxman.selection.Play();
            SceneManager.LoadScene(stageName);
            replayLevel3 = true;
            anim.SetBool("isOpen", false);
        }
    }

    public void backToMain()
    {
        MainMenuButtons.replayGame = false;
        sfxman.selection.Play();
        SceneManager.LoadScene(mainMenu);
        anim.SetBool("isOpen", false);
    }

    public void closeTab()
    {
        sfxman.selection.Play();
        anim.SetBool("isOpen", false);
    }
}
