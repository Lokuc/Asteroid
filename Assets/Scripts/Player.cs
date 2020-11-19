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
    private GameObject bull;
    private bool _miniGun;
    private float timeMiniGun;
    public GameObject bullet;
    public GameObject bulletMiniG;
    void Start()
    {
        Asteroid.score = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        tmp = new Vector2();
        vector = new Vector2();
    }

    public void miniGun()
    {
        _miniGun = true;
        timeMiniGun = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_miniGun)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Dj.getInstant().play(Dj.Sound.Shot);
                ShotMiniGun();
            }
            timeMiniGun += Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Dj.getInstant().play(Dj.Sound.Shot);
                Shot();
            }
        }
        if (timeMiniGun > 10f)
        {
            _miniGun = false;
        }
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
    
    
    
    private void Shot()
    {
        bull=Instantiate(bullet);
        vector = transform.position;
        vector.x += rigidbody.transform.up.x/3;
        vector.y += rigidbody.transform.up.y/3;
        bull.transform.position = vector;
        bull.GetComponent<Rigidbody2D>().AddForce(rigidbody.transform.up * 500, ForceMode2D.Force);
    }
    
    private void ShotMiniGun()
    {
        bull=Instantiate(bulletMiniG);
        vector = transform.position;
        vector.x += rigidbody.transform.up.x/3;
        vector.y += rigidbody.transform.up.y/3;
        bull.transform.position = vector;
        bull.GetComponent<Rigidbody2D>().AddForce(rigidbody.transform.up * 700, ForceMode2D.Force);
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
