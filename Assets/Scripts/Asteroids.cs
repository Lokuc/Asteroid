
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    private float time = 0f;
    public GameObject [] aste;
    public static GameObject[] ast;
    private System.Random random;
    private int tmp;
    private GameObject tmpGame;


    void Start()
    {
        random = new System.Random();
        ast = aste;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            spawnn();
            time = 0;
        }

    }

    private Asteroid astes;

    private void spawnn()
    {
        tmp = random.Next(3);
        tmpGame = Instantiate(ast[tmp]);
        astes = (Asteroid)tmpGame.GetComponent(typeof(Asteroid));
        astes.spawn();

    }

    
}
