using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dj.getInstant().play(Dj.Sound.Menu);
    }

    public void onClick()
    {
        Dj.getInstant().stop(Dj.Sound.Menu);
        SceneManager.LoadScene("MainGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
