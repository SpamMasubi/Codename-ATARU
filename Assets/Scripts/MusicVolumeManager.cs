using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPrefs = "MusicPref";

    private int firstPlayInt;

    public Slider MusicSlider;
    private float MusicFloat;

    public AudioSource[] MusicAudio;
    //float nextTimeToSearch = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            MusicFloat = 0.25f;
            MusicSlider.value = MusicFloat;
            PlayerPrefs.SetFloat(MusicPrefs, MusicFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            MusicFloat = PlayerPrefs.GetFloat(MusicPrefs);
            MusicSlider.value = MusicFloat;
        }
    }

    /*
    public void FixedUpdate()
    {
        if (MusicSlider == null)
        {
            FindSlider();
            return;
        }
        {
            saveMusicSetting();
            updateMusic();
        }

    }*/

    public void saveMusicSetting()
    {
        PlayerPrefs.SetFloat(MusicPrefs, MusicSlider.value);
    }


    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            saveMusicSetting();
        }
    }

    public void updateMusic()
    {
        for (int i = 0; i < MusicAudio.Length; i++)
        {
            MusicAudio[i].volume = MusicSlider.value;
        }
    }

    /*
    void FindSlider()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject slider = GameObject.FindGameObjectWithTag("MusicSlider");
            if (slider != null)
            {
                MusicSlider = (Slider)FindObjectsOfType(typeof(Slider))[0];
            }
            nextTimeToSearch = Time.time + 0.2f;
        }
    }*/
}
