using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public Animator anim;
    public GameObject nextButton;
    public string levelScene;
    public Text endDialogue;
    public GameObject[] custcenes;

    private SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButtons.newGame = false;
        MainMenuButtons.level1 = false;
        AttackHeliBoss.isBossDead = false;
        StealthFighterBoss.isBossDead = false;
        FlyingFortress.isBossDead = false;
        MainMenuButtons.easyMode = false;
        MainMenuButtons.mediumMode = false;
        MainMenuButtons.hardMode = false;
        sfx = FindObjectOfType<SFXManager>();
        MusicController.musicCanPlay = false;
        StartCoroutine(dialogueManager());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public IEnumerator dialogueManager()
    {
        anim.SetBool("canNext", false);
        yield return new WaitForSeconds(7.0f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        custcenes[0].SetActive(false);
        custcenes[1].SetActive(true);
        anim.SetBool("canNext", false);
        endDialogue.text = "The UN Task Force Commander congratulated me on my missions. " +
            "'Well done, ATARU.' He said. 'Though I have accomplished my mission, I felt this is just the beginning.";
        yield return new WaitForSeconds(7.0f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("canNext", false);
        endDialogue.text = "The Red Giant is still at large. " +
           "They still are a threat us and to the innocent people. " +
           "The world is still unsafe from those terrorists.";
        yield return new WaitForSeconds(7.0f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("canNext", false);
        endDialogue.text = "While General Karmov's death is a warning to them, we may have angered them. " +
           "The Red Giant will strike next...whenever they plan to do so. ";
        yield return new WaitForSeconds(7.0f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("canNext", false);
        custcenes[1].SetActive(false);
        custcenes[2].SetActive(true);
        endDialogue.text = "Whatever they are planning to strike next, we are ready for it. " +
            "We, the UN Task Force, will work with our allies and stop those terrorists from controlling the world.";
        yield return new WaitForSeconds(7.0f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("canNext", false);
        endDialogue.text = "Commander Megami...your time is up! Prepare yourself for our final showdown!";
        yield return new WaitForSeconds(6.0f);
        nextButton.SetActive(true);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(levelScene);
        sfx.selection.Play();
        custcenes[2].SetActive(false);
    }
}
