
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    
    public Slider sound;
    public Slider music;

    void Start()
    {
        sound.value = soundf;
        music.value = musicf;

    }

    public static bool ramka = true;
    public static float soundf = 0.0f;
    public static float musicf = 0.0f;
    public static int who;
    public void onClick()
    {
        soundf = sound.value;
        musicf = music.value;
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
