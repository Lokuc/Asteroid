using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using onClick;
using UnityEngine;

public class mGame : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ramka;
    public GameObject wall;
    private Vector2 _vector2;

    void Start()
    {
        if (Settings.ramka)
        {
            ramka.SetActive(true);
            _vector2=new Vector2(0,0.9f);
            wall.transform.position = _vector2;
            _vector2.x = 0.7f;
            _vector2.y = 0.7f;
            wall.transform.localScale = _vector2;
        }
        else
        {
            _vector2.x = 0;
            _vector2.y = 0;
            wall.transform.position = _vector2;
            _vector2.x = 1;
            _vector2.y = 1;
            wall.transform.localScale = _vector2;
            ramka.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
