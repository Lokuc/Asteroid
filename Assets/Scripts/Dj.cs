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
    public Text score;

    private static AudioSource audio;

    private static Dj instant;

    public static Dj getInstant()
    {
        return instant;
    }

    public void setScore(int scr)
    {
        score.text = scr + "";
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
        Boom
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
