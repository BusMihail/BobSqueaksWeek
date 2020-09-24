using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource audioSource;

    public AudioClip win;
    public AudioClip lose;
    public AudioClip alarm;
    public AudioClip sprayEmpty;
    public AudioClip sprayFull;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWin()
    {
        audioSource.clip = win;
        audioSource.Play();
    }

    public void PlayLose()
    {
        audioSource.clip = lose;
        audioSource.Play();
    }

    public void PlayAlarm()
    {
        audioSource.clip = alarm;
        audioSource.Play();
    }

    public void PlaySprayEmpty()
    {
        audioSource.clip = sprayEmpty;
        audioSource.Play();
    }

    public void PlaySprayFull()
    {
        audioSource.clip = sprayFull;
        audioSource.Play();
    }
}
