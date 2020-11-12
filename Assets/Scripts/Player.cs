using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private Vector2 vector;
    private Vector2 tmp;
    private float rotate = 0;
    public float forse;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        tmp = new Vector2();
        vector = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        tmp = rigidbody.velocity;
        if (tmp.x < 0.05 && tmp.x > -0.05)
        {
            tmp.x = 0;
        }
        else
        {
            if (tmp.x > 0)
            {
                tmp.x -= 0.05f;
            }
            else
            {
                tmp.x += 0.05f;
            }
        }
        if (tmp.y < 0.05 && tmp.y > -0.05)
        {
            tmp.y = 0;
        }
        else
        {
            if (tmp.y > 0)
            {
                tmp.y -= 0.05f;
            }
            else
            {
                tmp.y += 0.05f;
            }
        }
        rigidbody.velocity = tmp;
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(transform.up*0.2f, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotate -= 4;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotate+=4;
        }
        rigidbody.rotation = rotate;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //5 8.7
        if (collision.tag.Equals("Wall"))
        {
            tmp = gameObject.transform.position;
            switch (collision.name)
            {
                case "Up":
                    tmp.y = -5;
                    break;
                case "Down":
                    tmp.y = 5;
                    break;
                case "Left":
                    tmp.x = 8.7f;
                    break;
                case "Right":
                    tmp.x = -8.7f;
                    break;
            }
            gameObject.transform.position = tmp;
        }else if (collision.tag.Equals("Asteroids"))
        {
            Dj.getInstant().play(Dj.Sound.Dead);
            SceneManager.LoadScene("MainGame");
        }
    }
}
