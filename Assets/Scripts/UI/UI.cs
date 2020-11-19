using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text score;
    
    private static UI ui;

    public static UI getUI()
    {
        return ui;
    }
    // Start is called before the first frame update
    void Start()
    {
        ui = this;
    }

    public void setScore(int scr)
    {
        score.text = scr + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
