
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    private float time = 0f;
    public GameObject [] aste;
    public static GameObject[] ast;
    private System.Random random;
    private int tmp;
    private Rigidbody2D rigidbody;
    private static List<GameObject> asteroid;
    private int count = -1;
    // Start is called before the first frame update
    void Start()
    {
        asteroid = new List<GameObject>();
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
        count++;
        asteroid.Add(Instantiate(ast[tmp]));
        astes = (Asteroid)asteroid[count].GetComponent(typeof(Asteroid));
        astes.spawn();

    }

    
}
