using onClick;
using UnityEngine;

public class mGame : MonoBehaviour
{
    

    public GameObject ramka;
    public GameObject wall;
    private Vector2 _vector2;
    public GameObject ramlaComponent;
    public GameObject score;
    public GameObject scoreRamka;

    void Start()
    {
        if (Settings.ramka)
        {
            //score.transform.position = new Vector2(-820,369);
            score.transform.position = new Vector2((float) -7.6,(float) 3.4);
            ramlaComponent.SetActive(true);
            ramka.SetActive(true);
            scoreRamka.SetActive(true);
            _vector2=new Vector2(0,0.9f);
            wall.transform.position = _vector2;
            _vector2.x = 0.7f;
            _vector2.y = 0.7f;
            wall.transform.localScale = _vector2;
        }
        else
        {
            score.transform.position = new Vector2((float) -7.6, (float)4.6);
            scoreRamka.SetActive(false);
            _vector2.x = 0;
            _vector2.y = 0;
            wall.transform.position = _vector2;
            _vector2.x = 1;
            _vector2.y = 1;
            wall.transform.localScale = _vector2;
            ramka.SetActive(false);
            ramlaComponent.SetActive(false);
        }
    }

    
}
