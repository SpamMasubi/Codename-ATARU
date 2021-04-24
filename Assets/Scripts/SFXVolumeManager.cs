using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXVolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string SFXPrefs = "SFXPref";

    private int firstPlayInt;

    public Slider SFXSlider;
    private float SFXFloat;

    public AudioSource[] SFXAudio;
    //float nextTimeToSearch = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            SFXFloat = 0.75f;
            SFXSlider.value = SFXFloat;
            PlayerPrefs.SetFloat(SFXPrefs, SFXFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            SFXFloat = PlayerPrefs.GetFloat(SFXPrefs);
            SFXSlider.value = SFXFloat;
        }
    }

    /*
    public void FixedUpdate()
    {
        if (SFXSlider == null)
        {
            FindSlider();
            return;
        }
        {
            saveSFXSetting();
            updateSounds();
        }

    }*/

    public void saveSFXSetting()
    {
        PlayerPrefs.SetFloat(SFXPrefs, SFXSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            saveSFXSetting();
        }
    }

    public void updateSounds()
    {
        for (int i = 0; i < SFXAudio.Length; i++)
        {
            SFXAudio[i].volume = SFXSlider.value;
        }
    }

    /*
    void FindSlider()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject Soundslider = GameObject.FindGameObjectWithTag("SFXSlider");
            if (Soundslider != null)
            {
                SFXSlider = (Slider)FindObjectsOfType(typeof(Slider))[1];
            }
            nextTimeToSearch = Time.time + 0.2f;
        }
    }*/
}
