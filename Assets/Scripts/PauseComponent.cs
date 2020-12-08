using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseComponent : MonoBehaviour
{

    public GameObject[] gameObjects;

    private bool p = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (p != Player.pause)
        {
            p = Player.pause;
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(p);
            }
        }
    }

    private void LateUpdate()
    {
        FixedUpdate();
    }
}
