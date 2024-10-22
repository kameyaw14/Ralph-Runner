using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }   

   private AudioSource audioSource;


    private void Awake()
    {
           
        audioSource = GetComponent<AudioSource>();

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this && instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip _sound)
    {
        audioSource.PlayOneShot(_sound);
    }

    public void PauseMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); // Stop the music
            Debug.Log("Music Stopped");
        }
    }

    public void UnPauseMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Restart the music
            Debug.Log("Music Restarted");
        }
    }

    public void PlayBackgroundMusic(AudioClip musicClip)
    {
        if (audioSource != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true; // Enable looping if it's background music
            audioSource.Play();
        }
    }


}
