using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Dj : MonoBehaviour
{
    public AudioClip boom;
    private static AudioClip dea;
    public AudioClip dead;
    public AudioClip shot;
    public AudioClip menu;

    private static AudioSource audio;

    private static Dj instant;

    public static Dj getInstant()
    {
        return instant;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audio = GetComponent<AudioSource>();
        dea = dead;
        if (instant == null)
        {
            instant = this;
        }

    }

    public enum Sound
    {
        Dead,
        Shot,
        Boom,
        Menu
    }

    public void play(Sound sound)
    {
        switch (sound)
        {
            case Sound.Dead:
                audio.PlayOneShot(dea);
                break;
            case Sound.Shot:
                audio.PlayOneShot(shot);
                break;
            case Sound.Boom:
                audio.PlayOneShot(boom);
                break;
            case Sound.Menu:
                //audio.loop = true;
                //audio.PlayOneShot(menu);
                break;
        }
    }

    public void stop(Sound sound)
    {
        switch (sound)
        {
            case Sound.Menu:
                audio.Stop();
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
