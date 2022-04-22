using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip quietSong;
    public AudioClip loudSong;
    public AudioSource audioSource;

    private bool nextIsLoud = false;

    void Start()
    {
        audioSource.loop = false;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (nextIsLoud)
            {
                audioSource.volume = 0.5f;
                nextIsLoud = false;
                audioSource.clip = loudSong;
                audioSource.Play();
            }
            else
            {
                audioSource.volume = 1.0f;
                nextIsLoud = true;
                audioSource.clip = quietSong;
                audioSource.Play();
            }
        }
    }
}
