using System;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] states;
    private int type=-1;
    
    
    void Start()
    {
        setType(0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            setType(5);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            setType(4);
        }else if (Input.GetKey(KeyCode.W))
        {
            setType(1);
        }else if (Input.GetKey(KeyCode.D))
        {
            setType(2);
        }else if (Input.GetKey(KeyCode.A))
        {
            setType(3);
        }else 
        { 
            setType(0);
        }
    }


    public void setType(int t)
    {
        if (t == type)
        {
            return;
        }

        type = t;     //0 none 1 up 2 left 3 right 4 rightUP 5 leftUP
        for(int i = 0; i < states.Length; i++)
        {
            states[i].SetActive(type==i);
        }
    }

}
