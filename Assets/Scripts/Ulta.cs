﻿using UnityEngine;

public class Ulta : MonoBehaviour
{

    private Vector2 _vector2;
    void Start()
    {
        _vector2=new Vector2(0.06f,0.06f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _vector2.x += 0.05f;
        _vector2.y += 0.05f;
        gameObject.transform.localScale = _vector2;
        if (_vector2.x > 4)
        {
            Destroy(gameObject);
        }
    }
}