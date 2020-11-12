
using System;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private static System.Random random = new System.Random();
    private static Vector2 vector = new Vector2();
    private int num;
    private int degree;
    private static int score = 0;

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        switch (gameObject.name)
        {
            case "Big(Clone)":
                num = 2;
                break;
            case "Middle(Clone)":
                num = 1;
                break;
            case "Small(Clone)":
                num = 0;
                break;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("BigWall"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag.Equals("Bullet"))
        {
            Dj.getInstant().play(Dj.Sound.Boom);
            score += 5;
            Dj.getInstant().setScore(score);
            if (num == 2)
            {
                
                GameObject go = Instantiate(Asteroids.ast[1]);
                Asteroid a = (Asteroid)go.GetComponent(typeof(Asteroid));
                a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
                go = Instantiate(Asteroids.ast[1]);
                a = (Asteroid)go.GetComponent(typeof(Asteroid));
                a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
            }
            else if (num == 1)
            {
                GameObject go = Instantiate(Asteroids.ast[0]);
                Asteroid a = (Asteroid)go.GetComponent(typeof(Asteroid));
                a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
                go = Instantiate(Asteroids.ast[0]);
                a = (Asteroid)go.GetComponent(typeof(Asteroid));
                a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
            }

            
            
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }

    public void spawn()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        switch (random.Next(4))
        {
            case 0: //Right
                vector.x = -12;
                vector.y = random.Next(-5, 5);
                rigidbody.transform.up = DegreeToVector2(30f - (float)random.Next(60));
                rigidbody.transform.position = vector;
                break;
            case 1: //Down
                vector.y = -7;
                vector.x = random.Next(-8, 8);
                rigidbody.transform.up = DegreeToVector2(120f - (float)random.Next(70));
                rigidbody.transform.position = vector;
                break;
            case 2: //Left
                vector.x = 12;
                vector.y = random.Next(-5, 5);
                rigidbody.transform.up = DegreeToVector2(210f - (float)random.Next(60));
                rigidbody.transform.position = vector;
                break;
            case 3: //Up
                vector.y = 7;
                vector.x = random.Next(-8, 8);
                rigidbody.transform.up = DegreeToVector2(300f - (float)random.Next(70));
                rigidbody.transform.position = vector;
                break;
        }

        degree = (int) rigidbody.rotation;
        rigidbody.AddForce(rigidbody.transform.up * 100, ForceMode2D.Force);
    }
    public void spawn(float x, float y)
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.transform.up = DegreeToVector2((float)random.Next(360));
        vector.x = x;
        vector.y = y;
        rigidbody.transform.position = vector;
        degree = (int) rigidbody.rotation;
        rigidbody.AddForce(rigidbody.transform.up * 100, ForceMode2D.Force);
    }

    void Update()
    {
        degree += 3;
        rigidbody.rotation =degree;
        
    }
}
