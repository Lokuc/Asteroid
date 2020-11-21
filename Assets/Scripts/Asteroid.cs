
using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private static System.Random random = new System.Random();
    private static Vector2 vector = new Vector2();
    [NonSerialized]
    public int num;
    private int degree;
    public GameObject p;
    public GameObject a;
    public static int score;
    private Vector2 saveRotate;

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
            if (name != "boom" || collision.name == "bulletMiniG(Clone)"|| collision.name=="Bullet(Clone)")

        {
                Dj.getInstant().play(Dj.Sound.Boom);
                switch (num)
                {
                    case 2:
                        score += 1;
                        break;
                    case 1:
                        score += 3;
                        break;
                    case 0:
                        score += 5;
                        break;
                }

                if (random.Next(100) > 95)
                {
                    GameObject perk = Instantiate(p);
                    perk.transform.position = this.gameObject.transform.position;
                    perk.GetComponent<Rigidbody2D>().AddForce(saveRotate * 50, ForceMode2D.Force);
                }
                else if (random.Next(100) > 87)
                {
                    GameObject perk = Instantiate(a);
                    perk.transform.position = this.gameObject.transform.position;
                    perk.GetComponent<Rigidbody2D>().AddForce(saveRotate * 50, ForceMode2D.Force);
                }

                if (num == 2)
                {

                    GameObject go = Instantiate(Asteroids.ast[1]);
                    Asteroid a = (Asteroid) go.GetComponent(typeof(Asteroid));
                    a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
                    a.num = 1;
                    if (collision.name == "ulta(Clone)")
                    {
                        a.name = "boom";
                    }

                    go = Instantiate(Asteroids.ast[1]);
                    a = (Asteroid) go.GetComponent(typeof(Asteroid));
                    a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
                    a.num = 1;
                    if (collision.name == "ulta(Clone)")
                    {
                        a.name = "boom";
                    }

                }
                else if (num == 1)
                {
                    GameObject go = Instantiate(Asteroids.ast[0]);
                    Asteroid a = (Asteroid) go.GetComponent(typeof(Asteroid));
                    a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
                    a.num = 0;
                    if (collision.name == "ulta(Clone)")
                    {
                        a.name = "boom";
                    }

                    go = Instantiate(Asteroids.ast[0]);
                    a = (Asteroid) go.GetComponent(typeof(Asteroid));
                    a.spawn(gameObject.transform.position.x, gameObject.transform.position.y);
                    a.num = 0;
                    if (collision.name == "ulta(Clone)")
                    {
                        a.name = "boom";
                    }
                }



                UI.getUI().setScore(score);
                Destroy(this.gameObject);
                if (collision.name != "ulta(Clone)")
                {
                    Destroy(collision.gameObject);
                }
                
        }
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
        saveRotate = rigidbody.transform.up;
        degree = (int) rigidbody.rotation;
        rigidbody.AddForce(rigidbody.transform.up * 100, ForceMode2D.Force);
    }
    public void spawn(float x, float y)
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.transform.up = DegreeToVector2((float)random.Next(360));
        saveRotate = rigidbody.transform.up;
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
