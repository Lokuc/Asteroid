
using System;
using UI;
using UnityEngine;
using UnityEngine.Analytics;

public class Asteroid : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    //public static PolygonCollider2D plane;
    private static System.Random random = new System.Random();
    private static Vector2 vector = new Vector2();
    private int num;
    private int degree;
    [SerializeField]
    private GameObject p;
    [SerializeField]
    private GameObject a;
    public static int score;
    private Vector2 saveRotate;
    private static float dist;


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

    private void DestroyAndSpawn(Collider2D collision)
    {
        if (name != "boom" || collision.name == "bulletMiniG(Clone)"|| collision.name=="Bullet(Clone)"||(collision.name=="plane"&&Player.noDead))

        {
            Dj.getInstant().play(Dj.Sound.Boom);
            if (collision.name != "ulta(Clone)")
            {
                switch (num)
                {
                    case 2:
                        score += 10;
                        ProgresBarUlta.addTime(0.08f);
                        break;
                    case 1:
                        score += 20;
                        ProgresBarUlta.addTime(0.1f);
                        break;
                    case 0:
                        score += 30;
                        ProgresBarUlta.addTime(0.13f);
                        break;
                }
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

            if (num>0)
            {
                spawnOtherAsteroid(num - 1,collision);
            }

            UI.UI.getUI().setScore(score);
            Destroy(this.gameObject);
            switch (collision.name)
            {
                case "ulta(Clone)":
                    break;
                case "plane":
                    break;
                default:
                    Destroy(collision.gameObject);
                    break;
            }
                
                
        }
    }

    private void spawnOtherAsteroid(int type,Collider2D collision)
    {
        
        for (int i = 0; i < 2; i++)
        {
            GameObject asteroid = Instantiate(Asteroids.ast[type]);
            Asteroid asteroidClass = (Asteroid) asteroid.GetComponent(typeof(Asteroid));
            asteroidClass.spawn(gameObject.transform.position.x, gameObject.transform.position.y,random.Next(360));
            asteroidClass.num = type;
            if (collision.name == "ulta(Clone)")
            {
                asteroidClass.name = "boom";
            }
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
            DestroyAndSpawn(collision);
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
                break;
            case 1: //Down
                vector.y = -7;
                vector.x = random.Next(-8, 8);
                rigidbody.transform.up = DegreeToVector2(120f - (float)random.Next(70));
                break;
            case 2: //Left
                vector.x = 12;
                vector.y = random.Next(-5, 5);
                rigidbody.transform.up = DegreeToVector2(210f - (float)random.Next(60));
                break;
            case 3: //Up
                vector.y = 7;
                vector.x = random.Next(-8, 8);
                rigidbody.transform.up = DegreeToVector2(300f - (float)random.Next(70));
                break;
        }
        rigidbody.transform.position = vector;
        saveRotate = rigidbody.transform.up;
        degree = (int) rigidbody.rotation;
        rigidbody.AddForce(rigidbody.transform.up * 100, ForceMode2D.Force);
    }

    private void spawn(float x, float y, float degreeParametr)
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.transform.up = DegreeToVector2(degreeParametr);
        saveRotate = rigidbody.transform.up;
        vector.x = x;
        vector.y = y;
        rigidbody.transform.position = vector;
        degree = (int) rigidbody.rotation;
        rigidbody.AddForce(rigidbody.transform.up * 100, ForceMode2D.Force);
    }
    
    private static Vector2 DegreeToVector2(float degree)
    {
        return new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad));
    }

    void Update()
    {
        // dist = (plane.Distance(gameObject.GetComponent<BoxCollider2D>())).distance; \\ WARNING //DONT NEED NOW
        // if (dist < 1f)
        // {
        //     Dj.getInstant().warning(dist);
        // }
        
        degree += 3;
        rigidbody.rotation =degree;
        
    }
    
    
}
