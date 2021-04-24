using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolumeNextScene : MonoBehaviour
{
    private static readonly string SFXPrefs = "SFXPref";
    private float SFXFloat;

    public AudioSource[] SFXAudio;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {

        SFXFloat = PlayerPrefs.GetFloat(SFXPrefs);

        for (int i = 0; i < SFXAudio.Length; i++)
        {
            SFXAudio[i].volume = SFXFloat;
        }
    }
}
