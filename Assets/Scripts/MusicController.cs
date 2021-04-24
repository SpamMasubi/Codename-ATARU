using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    public AudioSource[] musicTracks;

    public int currentTrack;

    public static bool musicCanPlay = true;
    public static bool musicPause = false;

    // Use this for initialization
    void Awake()
    {
        /*
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }*/

    }

    // Update is called once per frame
    void Update()
    {

        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }

            if (musicPause)
            {
                musicTracks[currentTrack].Pause();
            }
            else if (!musicPause)
            {
                musicTracks[currentTrack].UnPause();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }

    }

    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }
}
