using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeNextScene : MonoBehaviour
{
    private static readonly string MusicPrefs = "MusicPref";
    private float MusicFloat;

    public AudioSource[] MusicAudio;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {

        MusicFloat = PlayerPrefs.GetFloat(MusicPrefs);

        for (int i = 0; i < MusicAudio.Length; i++)
        {
            MusicAudio[i].volume = MusicFloat;
        }
    }
}
