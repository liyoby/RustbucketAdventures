using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        bool isEnding = false;

        //End credits plays a video that has sound attached
        if(sceneName == "EndCredits")
        {
            isEnding = true;
        }

        //avoid overlapping sound by checking for end
        if (instance == null && isEnding == false)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        PlaySound("Theme");
    }

   public void AdjustVolume(string songName, float volumeLevel)
   {
        Sound s = Array.Find(sounds, sound => sound.name == songName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + songName + " not found!");
            return;
        }

        s.source.volume = volumeLevel;
   }

    public void StopLoop(string songName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == songName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + songName + " not found!");
            return;
        }

        s.source.loop = false;
    }
    public void PlaySound(string songName)
   {
       Sound s = Array.Find(sounds, sound => sound.name == songName);
       if(s == null)
       {
            Debug.LogWarning("Sound: " + songName + " not found!");
            return;
       }

        s.source.Play(); 
   }

    public void StopSound(string songName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == songName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + songName + " not found!");
            return;
        }

        s.source.Stop();
    }
}
