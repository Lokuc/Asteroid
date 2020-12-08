﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    void Start()
    {
        Dj.getInstant().play(Dj.Sound.Menu);
    }

    

    public void onClick(String b)
    {
        switch (b)
        {
            case "Play":
                Dj.getInstant().stop(Dj.Sound.Menu);
                SceneManager.LoadScene("MainGame");
                break;
            case "Settings":
                Dj.getInstant().stop(Dj.Sound.Menu);
                Settings.who = 0;
                SceneManager.LoadScene("Settings");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
