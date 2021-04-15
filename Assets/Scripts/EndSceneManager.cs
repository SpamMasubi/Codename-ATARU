using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{

    public Animator anim;

    public Text endDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator dialogueManager()
    {
        anim.SetBool("isOn", true);
        yield return new WaitForSeconds(8.0f);
        anim.SetBool("isOn", false);
        endDialogue.text = "However, the Red Giant is still at large. " +
           "They still are a threat us and to the innocent people. " +
           "The world is still unsafe from those terrorists.";
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("isOn", true);
        yield return new WaitForSeconds(8.0f);
        anim.SetBool("isOn", false);
        endDialogue.text = "While General Karmov's death is a warning to them, we may have angered them. " +
           "The Red Giant will strike next...whenever they plan to do so. ";
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("isOn", true);
        yield return new WaitForSeconds(8.0f);
        anim.SetBool("isOn", false);
        endDialogue.text = "Whatever they are planning to strike next, we are ready for it. " +
            "We, the UN Task Force, will work with our allies and stop terrorist activities ";
    }
}
