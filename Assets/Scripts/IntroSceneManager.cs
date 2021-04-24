using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public Animator anim;
    public string levelScene;
    public Text introDialogue;
    public SFXManager sfx;

    public GameObject[] cutscene;

    // Start is called before the first frame update
    void Start()
    {
        MusicController.musicCanPlay = false;
        sfx = FindObjectOfType<SFXManager>();
        StartCoroutine(dialogueManager());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public IEnumerator dialogueManager()
    {
        anim.SetBool("canNext", false);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        cutscene[0].SetActive(true);
        anim.SetBool("canNext", false);
        introDialogue.text = "A terrorist organization known as the Red Giant began their ruthless campaign of world domination. " +
            "From selling illicit weapons to waging war, the terrorists has become the UN's #1 priority. ";
        yield return new WaitForSeconds(7.5f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        cutscene[0].SetActive(false);
        cutscene[1].SetActive(true);
        anim.SetBool("canNext", false);
        introDialogue.text = "However, the United Nation's council members want to create a joint task force with the best soldiers they can find. " +
            "Thus, the UN has formed a anti-terrorist security force called the United Nation Task Force. ";
        yield return new WaitForSeconds(7.5f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("canNext", false);
        introDialogue.text = "The world leader began to ask their commanding officers to give them their best individual they can give to face off against the Red Giant terrorists.";
        yield return new WaitForSeconds(7.5f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        cutscene[1].SetActive(false);
        cutscene[2].SetActive(true);
        anim.SetBool("canNext", false);
        introDialogue.text = "Lt. Kazuki Yamamoto 'Codename: ATARU' of the US-Japan Joint Air Force was chosen to be part of the UN anti-terrorist task force.";
        yield return new WaitForSeconds(7.5f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("canNext", false);
        introDialogue.text = "Under the command of the UN Task Force Commander Mendou, ATARU will go into battle against them as they head towards into battle on the USS Tomobiki. ";
        yield return new WaitForSeconds(7.5f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        cutscene[2].SetActive(false);
        cutscene[3].SetActive(true);
        anim.SetBool("canNext", false);
        introDialogue.text = "ATARU will go face-to-face in his new fighter jet equipped with hi-tech armaments that will go against the Red Giant fleet of fighter jets.";
        yield return new WaitForSeconds(7.5f);
        anim.SetBool("canNext", true);
        yield return new WaitForSeconds(0.3f);
        cutscene[3].SetActive(false);
        cutscene[4].SetActive(true);
        anim.SetBool("canNext", false);
        introDialogue.text = "As he flies off into battle, ATARU will enter in a dogfight of Good vs. Evil.";
        yield return new WaitForSeconds(7.5f);
        anim.SetBool("canNext", true);
        cutscene[4].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelScene);
        MusicController.musicCanPlay = true;
    }

    public void skipIntro()
    {
        sfx.selection.Play();
        SceneManager.LoadScene(levelScene);
        MusicController.musicCanPlay = true;
    }

}
