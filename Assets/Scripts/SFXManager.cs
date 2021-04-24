using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource playerBullet;
    public AudioSource player1UP;
    public AudioSource powerUps;

    public AudioSource selection;
    public AudioSource gameOver;
    public AudioSource missiles;
    public AudioSource explosion;

    public AudioSource laser;
    public AudioSource enemyBullets;

    public AudioSource firstBossVoice;
    public AudioSource secondBossVoice;
    public AudioSource KarmovVoice;
    public AudioSource dialogue;

    private static bool sfxManagerExist;

    // Use this for initialization
    void Start()
    {
        /*
        if (!sfxManagerExist)
        {
            sfxManagerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/

    }
}
