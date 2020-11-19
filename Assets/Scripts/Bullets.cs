using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Bullets : MonoBehaviour
{
    public GameObject bull;
    public GameObject plane;
    private Vector2 vector2;
    private static List<GameObject> bullet;
    private Rigidbody2D rigidbody2D;
    private Rigidbody2D planerigidbody2D;
    private static int count;
    // Start is called before the first frame update
    void Start()         //DELET CLASS
    {
        bullet = new List<GameObject>();
        count = -1;
        planerigidbody2D = plane.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void removeBullet(GameObject bulle ){
        bullet.Remove(bulle);
        count--;
        Destroy(bulle);
    }


    private void Shot()
    {
        count++;
        bullet.Add(Instantiate(bull));
        vector2 = plane.transform.position;
        vector2.x += planerigidbody2D.transform.up.x/3;
        vector2.y += planerigidbody2D.transform.up.y/3;
        bullet[count].transform.position = vector2; //5 sec
        Destroy(bullet[count], 5);
        rigidbody2D = bullet[count].GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(planerigidbody2D.transform.up * 500, ForceMode2D.Force);

    }

   

}
