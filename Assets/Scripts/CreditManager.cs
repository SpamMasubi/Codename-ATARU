using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{

    private SFXManager sfx;
    public string loadScene;

    // Start is called before the first frame update
    void Start()
    {
        FlyingFortress.isBossDead = false;
        MusicController.musicCanPlay = false;
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton()
    {
        sfx.selection.Play();
        SceneManager.LoadScene(loadScene);
        MusicController.musicCanPlay = true;
    }
}
