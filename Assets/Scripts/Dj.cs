
using System;
using onClick;
using UnityEngine;

public class Dj : MonoBehaviour
{
    public AudioClip boom;
    private static AudioClip dea;
    public AudioClip dead;
    public AudioClip shot;
    public AudioClip menu;
    public AudioClip game;
    private float volume;
    public AudioSource music;
    public AudioSource sound;
    public AudioSource loopin;
    public AudioClip warnin;
    

    private static Dj instant;

    public static Dj getInstant()
    {
        return instant;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        loopin.loop = true;
        volume = 0f;
        DontDestroyOnLoad(this);
        
        dea = dead;
        if (instant == null)
        {
            instant = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        loopin.clip = warnin;
        loopin.Play();
        loopin.volume = 0f;

    }

    public enum Sound
    {
        Dead,
        Shot,
        Boom,
        Menu,
        Game
    }

    public void play(Sound sound)
    {
        music.volume = Settings.musicf;
        this.sound.volume = Settings.soundf;
        switch (sound)
        {
            case Sound.Dead:
                this.sound.PlayOneShot(dea);
                break;
            case Sound.Shot:
                this.sound.PlayOneShot(shot);
                break;
            case Sound.Boom:
                this.sound.PlayOneShot(boom);
                break;
            case Sound.Menu:
                music.loop = true;
                music.clip = menu;
                music.Play();
                break;
            case Sound.Game:
                music.loop = true;
                music.clip = game;
                music.Play();
                break;
        }
    }

    public void stop(Sound sound)
    {
        switch (sound)
        {
            case Sound.Menu:
                music.Stop();
                break;
            case Sound.Game:
                music.Stop();
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (loopin.volume != volume)
        {
            if (loopin.volume < volume)
            {
                loopin.volume += 0.1f;
                if (loopin.volume > volume)
                {
                    loopin.volume = volume;
                }
            }
            else if (loopin.volume > volume)
            {
                loopin.volume -= 0.01f;
                if (loopin.volume < volume)
                {
                    loopin.volume = volume;
                }
            }
        }

        //loopin.volume = volume/2;
        volume = 0f;
    }

    public void warning(float dist)
    {
        if (dist < 0.25f)
        {
            return;
        }
        if (volume < dist)
        {
            volume = dist;
        }
    }
}
