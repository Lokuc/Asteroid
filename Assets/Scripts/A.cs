﻿using UnityEngine;

public class A : MonoBehaviour
{
    
    private SpriteRenderer _spriteRenderer;
    private float alfa = 1f;
    private bool toUp;
    private Color _color;
    public static MainUpdaiter MainUpdaiter;
    
    
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _color=new Color(1f,1f,1f,1f);
        
    }

    
    void Update()
    {
        if (toUp)
        {
            alfa += 2.5f * Time.deltaTime;
            if (alfa > 1f)
            {
                alfa = 1f;
                toUp = false;
            }
        }
        else
        {
            alfa -= 2.5f * Time.deltaTime;
            if (alfa < 0f)
            {
                alfa = 0f;
                toUp = true;
            }
        }

        _color.a = alfa;
        _spriteRenderer.color = _color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "plane")
        {
            MainUpdaiter.activate(MainUpdaiter.Updates.DoubleGun);
            Destroy(this.gameObject);
        }else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
