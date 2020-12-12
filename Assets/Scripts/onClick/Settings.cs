using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace onClick
{
    public class Settings : MonoBehaviour
    {

    
        public Slider sound;
        public Slider music;

        void Start()
        {
            inSettings = true;
            sound.value = soundf;
            music.value = musicf;

        }

        public static bool ramka = true;
        public static float soundf = 0.0f;
        public static float musicf = 0.0f;
        public static bool inSettings;
        public static int who;
        public void onClick()
        {
            soundf = sound.value;
            musicf = music.value;
            switch (who)
            {
                case 0 :
                    SceneManager.LoadScene("Menu");
                    break;
                case 1:
                    //SceneManager.LoadScene(Player.scene);
                    //SceneManager.LoadScene(Player.scene.buildIndex, LoadSceneMode.Single);
                    //SceneManager.LoadScene(Player.scene,LoadSceneMode.Single);
                    inSettings = false;
                    SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Settings"));
                    //SceneManager.SetActiveScene(Player.scene);
                    
                    break;
                default:
                    SceneManager.LoadScene("Menu");
                    break;
            }
        
        }

    }
}
