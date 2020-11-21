using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject ulta;
    private int life = 3;
    private bool update;
    public GameObject[] LifeObjects;
    private float speedShotMiniGun = 0f;
    private bool pressShotMini = false;
    private bool updateMiniGun = false;
    private float updateGun = 0f;
    private float timeUlta = 0f;
    void Start()
    {
        Asteroid.score = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        tmp = new Vector2();
        vector = new Vector2();
        Dj.getInstant().play(Dj.Sound.Game);
        update = false;
        
    }

    public void miniGun()
    {
        _miniGun = true;
        timeMiniGun = 0f;
    }

    public void doubleGun()
    {
        update = true;
    }

    // Update is called once per frame
    void Update()
    { 
        
        if (_miniGun)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                pressShotMini = true;
            }
            else
            {
                pressShotMini = false;
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
        if (timeMiniGun > 5f)
        {
            _miniGun = false;
            pressShotMini = false;
            timeMiniGun = 0f;
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

        timeUlta += Time.deltaTime;
        if (timeUlta > 15f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                superShot();
                timeUlta = 0f;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotate+=4;
        }
        rigidbody.rotation = rotate;
        
        
    }

    private void FixedUpdate()
    {
        if (pressShotMini)
        {
            speedShotMiniGun += Time.fixedDeltaTime;
            if (update)
            {
                if (speedShotMiniGun > 0.15f)
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


    public void superShot()
    {
        GameObject ult = Instantiate(ulta);
        vector.x = 0.06f;
        vector.y = 0.06f;
        ult.transform.localScale = vector;
        ult.transform.position = gameObject.transform.position;
    }



    private void Shot()
    {
        if (!updateMiniGun)
        {
            bull = Instantiate(bullet);
            vector = transform.position;
            if (update)
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

            if (update)
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
            if (update)
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
            if (update)
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
    {   //5 8.7
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
            life--;
            LifeObjects[life].SetActive(false);
            update = false;
            updateMiniGun = false;
            if (life <= 0)
            {
                Dj.getInstant().stop(Dj.Sound.Game);
                Dj.getInstant().play(Dj.Sound.Dead);
                
                SceneManager.LoadScene("MainGame");
            }
            else
            {
                Dj.getInstant().play(Dj.Sound.Boom);
            }
        }
    }
}
