using onClick;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private new Rigidbody2D rigidbody;
    private Vector2 vector;
    private Vector2 tmp;
    private float rotate;
    private GameObject bull;
    public GameObject bullet;
    public GameObject bulletMiniG;
    public GameObject ulta;
    private int life = 3;
    public GameObject[] LifeObjects;
    private float speedShotMiniGun;
    private bool pressShotMini;
    private bool updateMiniGun;
    public static bool noDead;
    private float immortal;
    private Color color;
    private bool toUp;
    private float alfa;
    private SpriteRenderer _spriteRenderer;
    public static bool pause;
    public GameObject deadScreen;
    private bool dead;
    public GameObject buttonSpace;
    public GameObject joystick;
    public MainUpdaiter updaiter;


    void Start()
    {
        P.updaiter = updaiter;
        A.MainUpdaiter = updaiter;
        Asteroid.plane = gameObject.GetComponent<PolygonCollider2D>();
        setPause(false);
        dead = false;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        toUp = false;
        color=new Color(1f,1f,1f,1f);
        noDead = false;
        Asteroid.score = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        tmp = new Vector2();
        vector = new Vector2();
        Dj.getInstant().play(Dj.Sound.Game);

    }

    

    private void setPause()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1f;
        }
        else
        {
            pause = true;
            Time.timeScale = 0f;
        }
    }

    private void setPause(bool paus)
    {
        
        Player.pause = paus;
        Time.timeScale = paus?0f:1f;
    }
    
    
    void Update()
    {
        
        if (dead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
               restart();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                setPause();
            }
        }
        if (!pause)
        {
            if (updaiter.getActive(MainUpdaiter.Updates.MiniGun))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    ((CustomButton)(buttonSpace.GetComponent(typeof(CustomButton)))).setActive(true);
                    pressShotMini = true;
                }
                else
                {
                    ((CustomButton)(buttonSpace.GetComponent(typeof(CustomButton)))).setActive(false);
                    pressShotMini = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ((CustomButton)(buttonSpace.GetComponent(typeof(CustomButton)))).setActive(true);
                    Dj.getInstant().play(Dj.Sound.Shot);
                    Shot();
                }
                else
                {
                    ((CustomButton)(buttonSpace.GetComponent(typeof(CustomButton)))).setActive(false);
                }
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
                rigidbody.AddForce(transform.up * 0.2f, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rotate -= 4;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ((ProgresBarUlta)ulta.GetComponent(typeof(ProgresBarUlta))).UltaShot(gameObject.transform.position);
            }

                if (Input.GetKey(KeyCode.A))
            {
                rotate += 4;
            }

            rigidbody.rotation = rotate;
        }

        joystickset();

    }

    public void restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void settings()
    {
        Settings.who = 1;
        SceneManager.LoadScene("Settings");
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void joystickset()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            ((Joystick)(joystick.GetComponent(typeof(Joystick)))).setType(5);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            ((Joystick)(joystick.GetComponent(typeof(Joystick)))).setType(4);
        }else if (Input.GetKey(KeyCode.W))
        {
            ((Joystick)(joystick.GetComponent(typeof(Joystick)))).setType(1);
        }else if (Input.GetKey(KeyCode.D))
        {
            ((Joystick)(joystick.GetComponent(typeof(Joystick)))).setType(2);
        }else if (Input.GetKey(KeyCode.A))
        {
            ((Joystick)(joystick.GetComponent(typeof(Joystick)))).setType(3);
        }else 
        {
            ((Joystick)(joystick.GetComponent(typeof(Joystick)))).setType(0);
        }
        
    }

    private void FixedUpdate()
    {
        if (!pause)
        {
            if (noDead)
            {
                immortal -= Time.fixedDeltaTime;
                if (immortal > 0f)
                {
                    if (toUp)
                    {
                        alfa += 25f * Time.deltaTime;
                        if (alfa > 1f)
                        {
                            alfa = 1f;
                            toUp = false;
                        }
                    }
                    else
                    {
                        alfa -= 25f * Time.deltaTime;
                        if (alfa < 0f)
                        {
                            alfa = 0f;
                            toUp = true;
                        }
                    }

                    color.a = alfa;
                    _spriteRenderer.color = color;
                }
                else
                {
                    noDead = false;
                    color.a = 1f;
                    _spriteRenderer.color = color;
                }
            }
            
            if (pressShotMini)
            {
                speedShotMiniGun += Time.fixedDeltaTime;
                if (updaiter.getActive(MainUpdaiter.Updates.DoubleGun))
                {
                    if (speedShotMiniGun > 0.05f)
                    {
                        Dj.getInstant().play(Dj.Sound.Shot);
                        ShotMiniGun();
                        speedShotMiniGun = 0f;
                    }
                }
                else
                {
                    if (speedShotMiniGun > 0.3f)
                    {
                        Dj.getInstant().play(Dj.Sound.Shot);
                        ShotMiniGun();
                        speedShotMiniGun = 0f;
                    }
                }


            }
            
        }
    }

    



    private void Shot()
    {
        if (!updateMiniGun)
        {
            bull = Instantiate(bullet);
            vector = transform.position;
            if (updaiter.getActive(MainUpdaiter.Updates.DoubleGun))
            {
                updateMiniGun = true;
                vector.x += rigidbody.transform.right.x / 10f;
                vector.y += rigidbody.transform.right.y / 10f;
            }
            else
            {
                vector.x += rigidbody.transform.up.x / 3;
                vector.y += rigidbody.transform.up.y / 3;

            }

            bull.transform.position = vector;
            bull.GetComponent<Rigidbody2D>().AddForce(rigidbody.transform.up * 500, ForceMode2D.Force);

        }
        else
        {

            if (updaiter.getActive(MainUpdaiter.Updates.DoubleGun))
            {
                bull = Instantiate(bullet);
                vector = transform.position;
                vector.x -= rigidbody.transform.right.x / 10f;
                vector.y -= rigidbody.transform.right.y / 10f;
                bull.transform.position = vector;
                bull.GetComponent<Rigidbody2D>().AddForce(rigidbody.transform.up * 500, ForceMode2D.Force);
                updateMiniGun = false;
            }
        }


    }
    
    private void ShotMiniGun()
    {
        if (!updateMiniGun)
        {
            bull = Instantiate(bulletMiniG);
            vector = transform.position;
            if (updaiter.getActive(MainUpdaiter.Updates.DoubleGun))
            {
                updateMiniGun = true;
                vector.x += rigidbody.transform.right.x / 10f;
                vector.y += rigidbody.transform.right.y / 10f;
            }
            else
            {
                vector.x += rigidbody.transform.up.x / 3;
                vector.y += rigidbody.transform.up.y / 3;

            }

            bull.transform.position = vector;
            bull.GetComponent<Rigidbody2D>().AddForce(rigidbody.transform.up * 700, ForceMode2D.Force);
        }
        else
        {
            if (updaiter.getActive(MainUpdaiter.Updates.DoubleGun))
            {
                bull = Instantiate(bulletMiniG);
                vector = transform.position;
                vector.x -= rigidbody.transform.right.x / 10f;
                vector.y -= rigidbody.transform.right.y / 10f;
                bull.transform.position = vector;
                bull.GetComponent<Rigidbody2D>().AddForce(rigidbody.transform.up * 700, ForceMode2D.Force);
                updateMiniGun = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.tag.Equals("Wall"))
        {
            tmp = gameObject.transform.position;
            switch (collision.name)
            {
                case "Up":
                    if (Settings.ramka)
                    {
                        tmp.y = -2.8f;
                    }
                    else
                    {
                        tmp.y = -5;
                    }
                    break;
                case "Down":
                    if (Settings.ramka)
                    {
                        tmp.y = 4.3f;
                    }
                    else
                    {
                        tmp.y = 5;
                    }
                    break;
                case "Left":
                    if (Settings.ramka)
                    {
                        tmp.x = 6.4f;
                    }
                    else
                    {
                        tmp.x = 8.7f;
                    }
                    break;
                case "Right":
                    if (Settings.ramka)
                    {
                        tmp.x = -6.3f;
                    }
                    else
                    {
                        tmp.x = -8.7f;
                    }
                    break;
            }
            gameObject.transform.position = tmp;
        }else if (collision.tag.Equals("Asteroids"))
        {
            if (!noDead)
            {
                life--;
                LifeObjects[life].SetActive(false);
                updaiter.deActivate(MainUpdaiter.Updates.DoubleGun);
                updateMiniGun = false;
                if (life <= 0)
                {
                    setPause(true);
                    dead = true;
                    Dj.getInstant().stop(Dj.Sound.Game);
                    Dj.getInstant().play(Dj.Sound.Dead);
                    deadScreen.SetActive(true);
                }
                else
                {
                    Dj.getInstant().play(Dj.Sound.Boom);
                    vector.x = 0;
                    vector.y = 0;
                    vector.x = 0;
                    rigidbody.velocity = vector;
                    gameObject.transform.position = vector;
                    noDead = true;
                    immortal = 3f;
                }
            }
            else
            {
                //((Asteroid)collision.GetComponent(typeof(Asteroid))).DestroyAndSpawn(gameObject.GetComponent<Collider2D>());
            }
        }
    }
}
