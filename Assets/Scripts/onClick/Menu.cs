using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace onClick
{
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
                    //SceneManager.LoadScene("MainGame");
                    SceneManager.LoadScene("MainGame");
                    break;
                case "Settings":
                    Dj.getInstant().stop(Dj.Sound.Menu);
                    Settings.who = 0;
                    SceneManager.LoadScene("Settings");
                    break;
            }
        }


    }
}
