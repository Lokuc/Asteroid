
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{


    public Toggle checkRamka;
    public Slider sound;
    public Slider music;

    void Start()
    {
        sound.value = soundf;
        music.value = musicf;
        checkRamka.isOn = ramka;

    }

    public static bool ramka = false;
    public static float soundf = 0.2f;
    public static float musicf = 0.2f;

    public void onClick()
    {
        soundf = sound.value;
        musicf = music.value;
        ramka = checkRamka.isOn;
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
