using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{

    public GameObject none;
    public GameObject up;
    public GameObject left;
    public GameObject rigth;
    public GameObject rigthUp;
    public GameObject leftUp;


    private int type=-1;
    // Start is called before the first frame update
    void Start()
    {
        setType(0);
    }

    public void setType(int t)
    {
        if (t == type)
        {
            return;
        }

        type = t;
        switch (type)     //0 none 1 up 2 left 3 right 4 rightUP 5 leftUP
        {
            case 0:
                none.SetActive(true);
                up.SetActive(false);
                left.SetActive(false);
                rigth.SetActive(false);
                leftUp.SetActive(false);
                rigthUp.SetActive(false);
                break;
            case 1:
                none.SetActive(false);
                up.SetActive(true);
                left.SetActive(false);
                rigth.SetActive(false);
                leftUp.SetActive(false);
                rigthUp.SetActive(false);
                break;
            case 2:
                none.SetActive(false);
                up.SetActive(false);
                left.SetActive(true);
                rigth.SetActive(false);
                leftUp.SetActive(false);
                rigthUp.SetActive(false);
                break;
            case 3:
                none.SetActive(false);
                up.SetActive(false);
                left.SetActive(false);
                rigth.SetActive(true);
                leftUp.SetActive(false);
                rigthUp.SetActive(false);
                break;
            case 4:
                none.SetActive(false);
                up.SetActive(false);
                left.SetActive(false);
                rigth.SetActive(false);
                leftUp.SetActive(false);
                rigthUp.SetActive(true);
                break;
            case 5:
                none.SetActive(false);
                up.SetActive(false);
                left.SetActive(false);
                rigth.SetActive(false);
                leftUp.SetActive(true);
                rigthUp.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
