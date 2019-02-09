using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public static AudioManager instance;
   

    void Awake()
    {
       
        if (instance == null)//to check that we don't have more than one audiomnager in the scene; 
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(gameObject);//that is continue through the scenes



        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.Volume;
            s.source.loop = s.loop;

        }
        

    }

   
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //adding array in the beginning since we are looping through an array then find in "sounds" arrray for sound which has name equal to name passed
        if (s == null)
        {
            Debug.LogWarning("Sound Does not exist");
        }
        else s.source.Play();//play that sound
        
    }
}
